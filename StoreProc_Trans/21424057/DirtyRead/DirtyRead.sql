CREATE PROC SP_21424057_UPDATE_PRICE
	@ProductID AS INT, @NewPrice AS NUMERIC(18,0)
AS
BEGIN TRAN
	BEGIN TRY
		IF EXISTS(SELECT * FROM Products WHERE ID = @ProductID)
		BEGIN
			UPDATE Products
			SET Price = @NewPrice
			WHERE ID = @ProductID
			WAITFOR DELAY '00:00:10'
			UPDATE Products
			SET IsActive = NULL
			WHERE ID = @ProductID
		END
	END TRY
	BEGIN CATCH
			--PRINT N'LỖI HỆ THỐNG'
			--ROLLBACK TRAN
			--RETURN 1
		IF @@TRANCOUNT > 0
		BEGIN
			PRINT N'LỖI HỆ THỐNG'
			ROLLBACK TRAN
			DECLARE @ErrorMessage NVARCHAR(4000);
			DECLARE @ErrorSeverity INT;
			DECLARE @ErrorState INT;

			SELECT
				@ErrorMessage = ERROR_MESSAGE(),
				@ErrorSeverity = ERROR_SEVERITY(),
				@ErrorState = ERROR_STATE();

			RAISERROR (@ErrorMessage, -- Message text.
					   @ErrorSeverity, -- Severity.
					   @ErrorState -- State.
					   );
			RETURN 1
		END
	END CATCH
COMMIT TRAN
RETURN 0
GO

CREATE PROC SP_21424057_Order
	@ProductID AS INT, @Qty AS INT, @CustomerID AS INT, @TransferFee AS NUMERIC(18,2)
AS
BEGIN TRAN
	DECLARE @Price AS NUMERIC(18,2), @BranchID AS INT, @Amount AS NUMERIC(18,2), @TotalAmount AS NUMERIC(18,2), @OrderID AS INT, @OrderIDOut AS INT
	BEGIN TRY
		IF EXISTS(SELECT * FROM Products WITH(NOLOCK) WHERE ID = @ProductID)
		BEGIN
			SELECT @Price = Price FROM Products WITH(NOLOCK)
			WHERE ID = @ProductID

			SET @Amount = @Qty * @Price
			SET @TotalAmount = @Amount + @TransferFee

			SELECT @BranchID = BranchID 
			FROM ProductBranch
			WHERE ProductID = @ProductID

			---Khách hàng đặt hàng
			INSERT INTO Orders (BranchID, Payment, Amount, TotalAmount, CustomerID, CustomerCityID, CustomerDistrictID, 
							ProductFee, TransferFee, CustomerAddress, DriverID, Status) 
			VALUES(@BranchID, 1, @Amount, @TotalAmount, @CustomerID, 79, 7901, 0, @TransferFee, N'Address' , NULL, 1);
			SELECT @OrderID = SCOPE_IDENTITY()
			SET @OrderIDOut = @OrderID
			INSERT INTO OrderDetails (OrderID, ProductID, Quantity, Price, Amount) 
			VALUES(@OrderID, @ProductID, @Qty, @Price, @Amount)
		END
	END TRY
	BEGIN CATCH
		PRINT N'LỖI HỆ THỐNG'
		ROLLBACK TRAN
		RETURN 1
	END CATCH
COMMIT TRAN
RETURN 0
GO
