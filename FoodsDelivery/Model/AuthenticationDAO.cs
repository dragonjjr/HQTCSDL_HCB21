using FoodsDelivery.DB;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace FoodsDelivery.Model
{
    public class AuthenticationDAO
    {
        static string[] arrHexa = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F" };

        private BookingAndTransferFoodsEntities DB;

        public AuthenticationDAO()
        {
            DB = new BookingAndTransferFoodsEntities();
        }
        public int Login(string username, string password)
        {
            // return 0 : Sai tên tài khoản
            // return 1 : Đăng nhập thành công
            // return 2 : Sai mật khẩu
            var user = DB.Users.SingleOrDefault(u => u.UserName == username && u.IsActive == true);

            
            if (user != null)
            {
                var sha1 = new SHA1CryptoServiceProvider();
                var bytesPwhashSalt = StringToByteArray(user.Password);
                //SHA1 hash -> 20 byte => bytesPwhashSalt - 20 = byteSalt
                var LenPwhash = 20;
                var bytesPwhash = new byte[LenPwhash];
                Array.Copy(bytesPwhashSalt, bytesPwhash, LenPwhash);

                //hash password user input
                var PwUserInput = ASCIIEncoding.ASCII.GetBytes(password);
                var bytesPwUserHash = sha1.ComputeHash(PwUserInput);

                // chuyển array byte to string
                var strPwhash = ArrByteToString(bytesPwhash);
                var strPwUserIpHash = ArrByteToString(bytesPwUserHash);

                // Đăng nhập thành công
                if (strPwhash == strPwUserIpHash)
                {
                    return 1;
                }

                // Sai mật khẩu
                else
                {
                    return 2;
                }
            }

            // tên đăng nhập không tồn tại
            else
            {
                return 0;
            }
        }

        public int Register(string email, string username, string password, string confirmpass)
        {
            // return 0 : tài khoản đã tồn tại
            // return 1 : Đăng ký thành công
            // return 2 : Mật khẩu xác nhận lại ko đúng


            string strPwHash = HasPassword(password);
            // Lấy Username kiểm tra tồn tại chưa
            var user = DB.Users.SingleOrDefault(u => u.UserName == username);

            // Tên tài khoản đã tồn tại
            if (user != null)
            {
                return 0;
            }
            else
            {
                // Đăng ký thành công
                if (confirmpass == password)
                {
                    User users = new User();
                    users.Email = email;
                    users.UserName = username;
                    users.Password = strPwHash;
                    users.RoleID = 1;
                    //users. = DateTime.Now;
                    //users.LastUpdatedDate = DateTime.Now;
                    users.IsActive = false;

                    DB.Users.Add(users);
                    DB.SaveChanges();

                    return 1;
                }

                // Mật khẩu xác nhận lại không đúng
                else
                {
                    return 2;
                }
            }

        }

        private string HasPassword(string password)
        {
            //chuyển mật khẩu sang mảng byte
            var sha1 = new SHA1CryptoServiceProvider();
            var bytesPw = Encoding.ASCII.GetBytes(password);

            //salt và chuyển salt sang byte
            var salt = DateTime.Now.Millisecond.ToString();
            var bytesSalt = Encoding.ASCII.GetBytes(salt);

            //hash
            var bytesPwhashed = sha1.ComputeHash(bytesPw);

            //gắn salt lưu xuống database
            var bytesResult = new byte[bytesPwhashed.Length + bytesSalt.Length];
            Array.Copy(bytesPwhashed, bytesResult, bytesPwhashed.Length);
            Array.Copy(bytesSalt, 0, bytesResult, bytesPwhashed.Length, bytesSalt.Length);


            // chuyển array byte sang string
            var strPwHash = ArrByteToString(bytesResult);
            return strPwHash;
        }

        public bool CheckUserForGetPass(string email, string username)
        {
            var user = DB.Users.SingleOrDefault(u => u.UserName == username && u.Email == email);
            if (user != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ResetPass(string email, string username, string password)
        {
            var user = DB.Users.SingleOrDefault(u => u.UserName == username && u.Email == email);
            if (user != null)
            {
                user.Password = HasPassword(password);
                //user.LastUpdatedDate = DateTime.Now;
                return DB.SaveChanges()>1;
            }
            else
            {
                return false;
            }
        }

        private string ArrByteToString(Byte[] arrByte)
        {
            StringBuilder sb = new StringBuilder();

            foreach (byte b in arrByte)
            {
                //get 4 bit first
                sb.Append(arrHexa[(b >> 4)]);
                //get 4 bit second
                sb.Append(arrHexa[(b & 15)]);
            }

            return sb.ToString();
        }

        private byte[] StringToByteArray(string str)
        {
            return Enumerable.Range(0, str.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(str.Substring(x, 2), 16))
                             .ToArray();
        }
    }
}
