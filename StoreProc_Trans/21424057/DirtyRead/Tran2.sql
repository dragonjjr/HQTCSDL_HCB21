DECLARE @ProductID AS INT, @RS INT
SET @ProductID = 1
SELECT * FROM Products WITH(NOLOCK) where ID = @ProductID
EXEC @RS = SP_21424057_Order @ProductID, 2, 13, 20000
IF @RS = 1	PRINT N'ĐẶT HÀNG THÀNH CÔNG'ELSE	PRINT N'ĐẶT HÀNG THẤT BẠI'
SELECT * FROM OrderDetails