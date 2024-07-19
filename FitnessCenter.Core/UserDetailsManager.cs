using FitnessCenter.DTO;
using FitnessCenter.Data.Dao;
using FitnessCenter.Data.Crud;


namespace FitnessCenter.Core
{
    public class UserDetailsManager
    {
        public void CreateUserDetails(UserDetails userDetails)// verificar esto
        {
            UserCrudFactory userCrud = new UserCrudFactory();
            userCrud.Create(userDetails);
        }
    }
}