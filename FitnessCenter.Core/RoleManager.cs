using FitnessCenter.Data.Dao;
using FitnessCenter.Data.Crud.RoleCRUD;
using FitnessCenter.DTO.RoleDTO;
using FitnessCenter.DTO.AppointmentDTO;

namespace FitnessCenter.Core
{
    public class RoleManager
    {
        readonly RoleCrudFactory _roleCrudFactory;
        public RoleManager()
        {
            _roleCrudFactory = new RoleCrudFactory();
        }

        public Dictionary<string, string> CreateRole(Role role)
        {
            var result = _roleCrudFactory.Create(role);
            return result;
        }

        public List<Role> RetrieveAll()
        {
            var result = _roleCrudFactory.RetrieveAll();
            return result;
        }

        public Dictionary<string, string> UpdateRoleName(string oldRoleName, string newRoleName)
        {
            var result = _roleCrudFactory.UpdateRoleName(oldRoleName, newRoleName);
            return result;
        }

        public Dictionary<string, string> SetUserRole(int userID, string roleName)
        {
            var result = _roleCrudFactory.SetUserRole(userID, roleName);
            return result;
        }


    }

}
