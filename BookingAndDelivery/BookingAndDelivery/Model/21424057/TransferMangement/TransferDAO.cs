using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingAndDelivery.Model.TransferMangement
{
    public class TransferDAO
    {
        private BookingAndTransferFoodsEntities db;
        public TransferDAO()
        {
            db = new BookingAndTransferFoodsEntities();
        }

        public List<OrderVM> GetListOrder()
        {
            var rs = (from o in db.Orders
                      join pay in db.Dictionaries on o.Payment equals pay.ItemID
                      join city in db.Dictionaries on o.CustomerCityID equals city.ItemID
                      join dis in db.Dictionaries on o.CustomerDistrictID equals dis.ItemID
                      join st in db.Dictionaries on o.Status equals st.ItemID
                      where pay.Type == "PAYMENT" && city.Type == "CITY" && dis.Type == "DISTRICT" && st.Type == "TYPETRANSFER" && o.Status == 1
                      select new OrderVM
                      {
                          ID = o.ID,
                          Payment = pay.ItemName,
                          Amount = o.Amount,
                          TotalAmount = o.TotalAmount,
                          TransferFee = o.TransferFee,
                          City = city.ItemName,
                          District = dis.ItemName,
                          Adrress = o.CustomerAddress,
                          Status = st.ItemName
                      }).ToList();
            return rs;
        }

        public List<OrderVM> GetListTranferByID(int DriverID)
        {
            var rs = (from o in db.Orders
                      join pay in db.Dictionaries on o.Payment equals pay.ItemID
                      join city in db.Dictionaries on o.CustomerCityID equals city.ItemID
                      join dis in db.Dictionaries on o.CustomerDistrictID equals dis.ItemID
                      join st in db.Dictionaries on o.Status equals st.ItemID
                      where pay.Type == "PAYMENT" && city.Type == "CITY" && dis.Type == "DISTRICT" && st.Type == "TYPETRANSFER" && o.Status != 1 && o.DriverID == DriverID
                      select new OrderVM
                      {
                          ID = o.ID,
                          Payment = pay.ItemName,
                          Amount = o.Amount,
                          TotalAmount = o.TotalAmount,
                          TransferFee = o.TransferFee,
                          City = city.ItemName,
                          District = dis.ItemName,
                          Adrress = o.CustomerAddress,
                          Status = st.ItemName
                      }).ToList();
            return rs;
        }

        public bool ConfirmTransfer1(int ID, int DriverID)
        {
            try
            {
                return db.Database.ExecuteSqlCommand("EXEC SP_21424057_Transfer1 @OrderID, @DiverID", new SqlParameter("@OrderID", ID), new SqlParameter("@DiverID", DriverID)) > 0;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool ConfirmTransfer2(int ID, int DriverID)
        {
            try
            {
                return db.Database.ExecuteSqlCommand("EXEC SP_21424057_Transfer2 @OrderID, @DiverID", new SqlParameter("@OrderID", ID), new SqlParameter("@DiverID", DriverID)) > 0;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool ConfirmTransfer1_Fix(int ID, int DriverID)
        {
            try
            {
                return db.Database.ExecuteSqlCommand("EXEC SP_21424057_Transfer1_Fix @OrderID, @DiverID", new SqlParameter("@OrderID", ID), new SqlParameter("@DiverID", DriverID)) > 0;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool ConfirmTransfer2_Fix(int ID, int DriverID)
        {
            try
            {
                return db.Database.ExecuteSqlCommand("EXEC SP_21424057_Transfer2_Fix @OrderID, @DiverID", new SqlParameter("@OrderID", ID), new SqlParameter("@DiverID", DriverID)) > 0;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
    }

    public class OrderVM
    {
        public long ID { get; set; }
        public string Payment { get; set; }
        public decimal? Amount { get; set; }
        public decimal? TotalAmount { get; set; }
        public decimal? TransferFee { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Adrress { get; set; }
        public string Status { get; set; }
    }
}
