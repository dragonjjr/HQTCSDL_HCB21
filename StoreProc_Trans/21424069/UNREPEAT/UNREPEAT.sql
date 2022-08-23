﻿--CREATE 
ALTER
PROC USP_21424069_READ_DATA_PRODUCT
	@PRODUCT_ID BIGINT
AS
BEGIN TRAN
	BEGIN TRY
		IF NOT EXISTS(SELECT * 
					FROM Products P 
					WHERE P.ID = @PRODUCT_ID)
		BEGIN
			PRINT N'SẢN PHẨM KHÔNG TỒN TẠI'
			ROLLBACK TRAN
			RETURN 
		END
		
		ELSE
			DECLARE @Product_Name NVARCHAR(MAX) = (SELECT P.Name FROM Products P WHERE P.ID = @PRODUCT_ID)
		--ĐỂ TEST
		WAITFOR DELAY '0:0:05'
		---------
		SELECT * FROM Products P WHERE P.ID = @PRODUCT_ID

	END TRY
	BEGIN CATCH
		PRINT N'LỖI HỆ THỐNG'
		ROLLBACK TRAN
	END CATCH
COMMIT TRAN
GO

--CREATE 
ALTER
PROC USP_21424069_DELETE_DATA_PRODUCT
	@PRODUCT_ID BIGINT
AS
BEGIN TRAN
	BEGIN TRY
		IF NOT EXISTS (SELECT *
						FROM Products P
						WHERE P.ID = @PRODUCT_ID)
		BEGIN
			PRINT  N'SẢN PHẨM KHÔNG TỒN TẠI'
			ROLLBACK TRAN
			RETURN 1
		END

		DELETE 
		FROM Products
		WHERE ID = @PRODUCT_ID


	END TRY
	BEGIN CATCH
		PRINT N'LỖI HỆ THỐNG'
		ROLLBACK TRAN
		RETURN 1
	END CATCH
	
COMMIT TRAN
RETURN 0
GO