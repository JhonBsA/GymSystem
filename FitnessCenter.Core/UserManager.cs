﻿using FitnessCenter.DTO;
using FitnessCenter.Data.Dao;
using FitnessCenter.Data.Crud;


namespace FitnessCenter.Core
{
    public class UserManager
    {
        readonly UserCrudFactory userCrud = new UserCrudFactory();
        public Dictionary<string, string> CreateUsuario(UserDetails user)
        {

            return userCrud.Create(user);
        }

        public Dictionary<string, string> RetrieveByEmail(string email)
        {
            return userCrud.RetrieveByEmail(email);
        }

        public Dictionary<string, string> PasswordResetOTP(string Otp, string NewPassword)
        {
            var result = userCrud.PasswordResetOTP(Otp, NewPassword);
            return result;
        }

        public Dictionary<string, string> Login(string Email, string Password)
        {
            var result = userCrud.Login(Email, Password);
            return result;
        }

<<<<<<< HEAD
        public BaseClass GetUserByUserID(int UserID)
        {
            var result = userCrud.RetrieveById(UserID);
            return result;
        }
=======
>>>>>>> JBSA
    }
}