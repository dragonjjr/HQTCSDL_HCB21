using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodsDelivery.DB;

namespace FoodsDelivery.Model
{
    public class LoginModel
    {
        public static bool Login(string UserName, string password)
        {
            BookingAndTransferFoodsEntities dbContext = new BookingAndTransferFoodsEntities();
            if(UserName != string.Empty && password != string.Empty)
            {
                var model = dbContext.Users.Where(x => x.UserName == UserName && x.Password == password).FirstOrDefault();
                if(model != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
    }
}
