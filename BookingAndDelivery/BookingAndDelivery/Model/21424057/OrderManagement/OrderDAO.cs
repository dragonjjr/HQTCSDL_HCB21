using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BookingAndDelivery.Model.OrderManagement
{
    public class OrderDAO
    {
        private BookingAndTransferFoodsEntities db;
        public OrderDAO()
        {
            db = new BookingAndTransferFoodsEntities();
        }

        public List<ListOfProduct> GetProducts()
        {
            var rs = (from p in db.Products
                      join pb in db.ProductBranches on p.ID equals pb.ProductID
                      select new ListOfProduct
                      {
                          ID = p.ID,
                          Name = p.Name,
                          Price = p.Price,
                          Quantity = pb.Quantity
                      }).ToList();
            return rs;
        }

        public List<OrderVM> GetListOrder()
        {
            long user = long.Parse(Application.Current.Properties["UserID"].ToString());
            var rs = (from p in db.Products
                      join od in db.OrderDetails on p.ID equals od.ProductID
                      join o in db.Orders on od.OrderID equals o.ID
                      where o.CustomerID == user
                      select new OrderVM
                      {
                          ID = od.ID,
                          Name = p.Name,
                          Price = od.Price,
                          Quantity = od.Quantity,
                          Amount = od.Amount
                      }).ToList();
            return rs;
        }

        public bool Order(int ProductID, int Qty, long CustomerID, decimal TransferFee)
        {
            return db.Database.ExecuteSqlCommand("EXEC SP_21424057_Order @ProductID, @Qty, @CustomerID, @TransferFee", new SqlParameter("@ProductID", ProductID), new SqlParameter("@Qty", Qty), new SqlParameter("@CustomerID", CustomerID), new SqlParameter("@TransferFee", TransferFee)) > 0;
        }

        public bool Order_Fix(int ProductID, int Qty, long CustomerID, decimal TransferFee)
        {
            
            return db.Database.ExecuteSqlCommand("EXEC SP_21424057_Order_Fix @ProductID, @Qty, @CustomerID, @TransferFee", new SqlParameter("@ProductID", ProductID), new SqlParameter("@Qty", Qty), new SqlParameter("@CustomerID", CustomerID), new SqlParameter("@TransferFee", TransferFee)) > 0;
        }
    }

    public class ListOfProduct
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }
    }

    public class OrderVM
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }
        public decimal? Amount { get; set; }
    }
}
