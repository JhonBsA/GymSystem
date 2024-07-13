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
    }
}