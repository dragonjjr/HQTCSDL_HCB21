using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingAndDelivery.Model._21424069._21424069_Staff
{
    
    class _21424069_StaffDAO
    {
        private BookingAndTransferFoodsEntities db;

        public _21424069_StaffDAO()
        {
            db = new BookingAndTransferFoodsEntities();
        }

        public List<User_DAO> GetStaffs()
        {
            var rs = (from u in db.Users
                      where u.RoleID == 2
                      select new User_DAO
                      {
                          FullName = u.FullName,
                          Phone = u.Phone,
                          Address = u.Address,
                          Email = u.Email,
                          NameOfBank = u.NameOfBank,
                          BankAccount = u.BankAccount,
                          NumOfOrder = u.NumOfOrder

                      }).ToList();

            for (int i = 0; i < rs.Count; i++)
            {
                rs[i].STT = i + 1;
            }

            return rs;
        }

        public int Count_Staff()
        {
            int UsersCount = (from user in db.Users where user.RoleID == 2 select user.ID).Count();
            return UsersCount;
        }

        public bool AddStaff(string FullName, string Phone, string Address, string Email, string NameOfBank, string BankAccount, int NumOfOrder, Nullable<long> RoleID)
        {
            try
            {
                return db.Database.ExecuteSqlCommand("EXEC USP_21424069_INSERT_DATA_USERS @FullName, @Phone, @Address, @Email, @NameOfBank, @BankAccount, @NumOfOrder, @RoleID",
                    new SqlParameter("@FullName", FullName), new SqlParameter("@Phone", Phone), new SqlParameter("@Address", Address), new SqlParameter("@Email", Email), new SqlParameter("@NameOfBank", NameOfBank), 
                    new SqlParameter("@BankAccount", BankAccount), new SqlParameter("@NumOfOrder", NumOfOrder), new SqlParameter("@RoleID", RoleID)) > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


    }

    public class User_DAO
    {
        public int STT { get; set; }
        public long ID { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string NameOfBank { get; set; }
        public string BankAccount { get; set; }
        public int NumOfOrder { get; set; }
        public Nullable<long> RoleID { get; set; }
    }
}
