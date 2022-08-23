using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingAndDelivery.Model.ProductManagement
{
    public class ProductDAO
    {
        private BookingAndTransferFoodsEntities db;
        public ProductDAO()
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
            try
            {
                return db.Database.ExecuteSqlCommand("EXEC SP_21424057_UPDATE_PRICE @ProductID, @NewPrice", new SqlParameter("@ProductID", ID), new SqlParameter("@NewPrice", price)) > 0;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool UpdatePrice_Fix(int ID, decimal price)
        {
            try
            {
                return db.Database.ExecuteSqlCommand("EXEC SP_21424057_UPDATE_PRICE_Fix @ProductID, @NewPrice", new SqlParameter("@ProductID", ID), new SqlParameter("@NewPrice", price)) > 0;
            }
            catch (Exception)
            {

                return false;
            }

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
