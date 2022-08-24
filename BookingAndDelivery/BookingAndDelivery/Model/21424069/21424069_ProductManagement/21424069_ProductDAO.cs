using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingAndDelivery.Model._21424069
{
    class _21424069_ProductDAO
    {
        private BookingAndTransferFoodsEntities db;

        public _21424069_ProductDAO()
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

        public bool DeleteProduct(int ID)
        {
            try
            {
                return db.Database.ExecuteSqlCommand("EXEC USP_21424069_DELETE_DATA_PRODUCT @ProductID", new SqlParameter("@ProductID", ID)) > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public List<ProductVM> SearchProductID(long ID)
        {
            

            var rs = (from p in db.Products
                      where p.ID == ID
                      select new ProductVM
                      {
                          Name = p.Name,
                          Price = p.Price,
                      }).ToList();
            return rs;
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
