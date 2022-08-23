-- Khách hàng đặt đơn hàng
CREATE 
PROC USP_21424031_OrderProduct
	@BranchID AS INT,
	@TotalAmount AS INT,
	@CustomerID AS INT,
	@CustomerCityID AS INT,
	@CustomerDistrictID AS INT,
	@CustomerAddress AS nvarchar
AS
BEGIN TRAN
	
	BEGIN TRY
		Insert into Orders(BranchID,TotalAmount,CustomerID,CustomerCityID,CustomerDistrictID,CustomerAddress,Status) values(@BranchID,@TotalAmount,@CustomerID,@CustomerCityID,@CustomerDistrictID,@CustomerAddress,1)
	END TRY
	BEGIN CATCH
		DECLARE @ErrorMsg VARCHAR(2000)
		SELECT @ErrorMsg = N'Lỗi: ' + ERROR_MESSAGE()
		RAISERROR(@ErrorMsg, 16,1)
		ROLLBACK TRAN
		RETURN 0
	END CATCH

COMMIT TRAN
RETURN 1
GO

CREATE 
PROC USP_21424031_OrderProductDetail
	@OrderID AS INT,
	@ProductID AS INT,
	@Quantity AS INT,
	@Price AS INT,
	@Amount AS INT
AS
BEGIN TRAN
	
	BEGIN TRY
		Insert into OrderDetails(OrderID,ProductID,Quantity,Price,Amount) values(@OrderID,@ProductID,@Quantity,@Price,@Amount)
	END TRY
	BEGIN CATCH
		DECLARE @ErrorMsg VARCHAR(2000)
		SELECT @ErrorMsg = N'Lỗi: ' + ERROR_MESSAGE()
		RAISERROR(@ErrorMsg, 16,1)
		ROLLBACK TRAN
		RETURN 0
	END CATCH

COMMIT TRAN
RETURN 1
GO