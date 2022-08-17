using FoodsDelivery.DB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodsDelivery.Model
{
    public class ProductModel
    {
        private BookingAndTransferFoodsEntities db;
        public ProductModel()
        {
            db = new BookingAndTransferFoodsEntities();
        }
        public List<ProductVM> GetProducts()
        {
            var rs = (from p in db.Products
                     select new ProductVM
                     {
                         ID = p.ID,
                         Name = p.Name,
                         Price = p.Price,
                         IsActive = p.IsActive
                     }).ToList();
            return rs;
        }

        public bool UpdatePrice(int ID, decimal price)
        {
            return db.Database.ExecuteSqlCommand("EXEC SP_UPDATE_PRICE @ProductID, @NewPrice", new SqlParameter("@ProductID", ID), new SqlParameter("@NewPrice", price)) > 0;
        }
    }

    public class ProductVM
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public long IsActive { get; set; }
    }
}
