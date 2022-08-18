SELECT * FROM Orders
--Khách hàng hủy đơn hàng
EXEC USP_CancelOrder 7
SELECT * FROM Orders