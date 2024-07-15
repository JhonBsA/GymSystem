using FitnessCenter.DTO;
using FitnessCenter.Data.Dao;
using FitnessCenter.Data.Crud;


namespace FitnessCenter.Core
{
    public class UserManager
    {
        readonly UserCrudFactory userCrud = new UserCrudFactory();
        public void CreateUsuario(UserDetails user)
        {
            
            userCrud.Create(user);
        }

        public Dictionary<string, string> RetrieveByEmail(string email)
        {
            return userCrud.RetrieveByEmail(email);
        }
<<<<<<< HEAD

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

=======
>>>>>>> 2032cc1c34dfc49b772443d180f876b624aa8eed
    }
}