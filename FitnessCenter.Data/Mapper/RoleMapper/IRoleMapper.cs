using FitnessCenter.Data.Dao;
using FitnessCenter.DTO.RoleDTO;

namespace FitnessCenter.Data.Mapper.RoleMapper
{
    public interface IRoleMapper
    {
        Role BuildObject(Dictionary<string, object> objectRow);
        List<Role> BuildObjects(List<Dictionary<string, object>> objectRows);
        SqlOperation GetCreateStatement(Role entityDTO);
        SqlOperation GetUpdateRoleNameStatement(string oldRoleName, string newRoleName);
        SqlOperation GetRetrieveAllStatement(); 
    }
}


