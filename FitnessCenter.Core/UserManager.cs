using FitnessCenter.DTO;
using FitnessCenter.Data.Dao;
using FitnessCenter.Data.Crud;


namespace FitnessCenter.Core
{
    public class UserManager
    {
        public void CreateUsuario(UserDetails user)
        {
            UserCrudFactory userCrud = new UserCrudFactory();
            userCrud.Create(user);
        }
    }
}