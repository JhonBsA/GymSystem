using FitnessCenter.Data.Dao;
using FitnessCenter.DTO.GroupClassDTO;

namespace FitnessCenter.Data.Mapper.GroupClassMapper
{
    public interface IGroupClassMapper
    {
        GroupClass BuildObject(Dictionary<string, object> objectRow);
        List<GroupClass> BuildObjects(List<Dictionary<string, object>> objectRows);
        SqlOperation GetCreateGroupClassStatement(GroupClass entityDTO);
        SqlOperation GetUpdateGroupClassStatement(GroupClass entityDTO);
        SqlOperation GetDeleteGroupClassStatement(int classID);
        SqlOperation GetRetrieveAllGroupClassStatement();
        SqlOperation GetRetrieveGroupClassByClassIDStatement(int classID);
    }
}
