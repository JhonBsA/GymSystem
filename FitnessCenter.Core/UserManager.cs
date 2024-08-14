using FitnessCenter.DTO;
using FitnessCenter.Data.Dao;
using FitnessCenter.Data.Crud;
using System.Collections.Generic;

namespace FitnessCenter.Core
{
    public class UserManager
    {
        private readonly UserCrudFactory userCrud = new UserCrudFactory();
        private readonly IEmailService _emailService;

        public UserManager(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public Dictionary<string, string> CreateUsuario(UserDetails user)
        {
            var result = userCrud.Create(user);

            // Send email notification
            if (result != null && result.ContainsKey("Email"))
            {
                string userEmail = result["Email"];
                string subject = "New user created";
                string body = "Your account OTP Code: ";

                if (result.ContainsKey("OTPCode"))
                {
                    body += result["OTPCode"];
                }
                else
                {
                    body += "Not available";
                }

                _emailService.SendEmail(userEmail, subject, body);
            }

            return result;
        }


        public Dictionary<string, string> RetrieveByEmail(string email)
        {
            var result = userCrud.RetrieveByEmail(email);

            // Send email notification
            if (result != null && result.ContainsKey("Email"))
            {
                string userEmail = result["Email"];
                string subject = "Password reset code";
                string body = "Your account OTP Code: ";

                if (result.ContainsKey("OTPCode"))
                {
                    body += result["OTPCode"];
                }
                else
                {
                    body += "Not available";
                }

                _emailService.SendEmail(userEmail, subject, body);
            }

            return result;
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

        public BaseClass GetUserByUserID(int UserID)
        {
            var result = userCrud.RetrieveById(UserID);
            return result;
        }

        public Dictionary<string, string> UpdateUser(UserDetails user)
        {
            return userCrud.Update(user);
        }

        public Dictionary<string, string> DeleteUser(UserDetails user)
        {
            return userCrud.Delete(user);
        }
        public List<UserDetails> GetAllUsers()
        {
            return userCrud.RetrieveAll<UserDetails>();
        }

        public List<UserDetails> GetUsersByRole(string roleName)
        {
            var result = userCrud.GetUsersByRole(roleName);
            return result;
        }
    }
}