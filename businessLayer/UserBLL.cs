using DataLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace businessLayer
{
    public class UserBLL
    {
        private enum enMode { AddMode = 1, UpdateMode = 2 };
        enMode _mode = enMode.AddMode;


        private User _user;

        public UserBLL()
        {
            _user = new User();
            _mode = enMode.AddMode;
        }

        public UserBLL(User user)
        {
            _user = user;
            _mode = enMode.UpdateMode;
        }

        public User currentuser { get { return _user; } set { _user = value; } }


        public bool Add()
        {
          _user.UserId = UserDLL.Add(_user);
            return _user.UserId > 0;
        }

        public bool Update()
        {
          return  UserDLL.Update(_user);
        }

        public bool Delete(byte UserID)
        {
            return UserDLL.Delete(UserID);
        }

       static public async Task<DataTable> GetAllUsers()
        {
            return  await  UserDLL.GetAllUsers();
        }

        public async Task<User> GetUserByID(byte UserID)
        {
            return await UserDLL.GetUserByID(UserID);
        }

       static public async Task<User> GetUserForLogin(string UserName,string Password)
        {
            return await UserDLL.GetUserForLogin(UserName, Password);
        }

        public bool Save()
        {
            switch (_mode)
            {
                case enMode.AddMode:
                    if (Add())
                    {
                        _mode = enMode.UpdateMode;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    
                case enMode.UpdateMode:
                    return Update();
            }
            return false;
        }

       public static string ComputeHash(string input)
        {
            //SHA is Secutred Hash Algorithm.
            // Create an instance of the SHA-256 algorithm
            using (SHA256 sha256 = SHA256.Create())
            {
                // Compute the hash value from the UTF-8 encoded input string
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));


                // Convert the byte array to a lowercase hexadecimal string
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }
    }
}
