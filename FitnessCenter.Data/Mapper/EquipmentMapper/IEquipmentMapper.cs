using FitnessCenter.Data.Dao;
using FitnessCenter.DTO.EquipmentDTO;

namespace FitnessCenter.Data.Mapper.EquipmentMapper
{
    public interface IEquipmentMapper
    {
        Equipment BuildObject(Dictionary<string, object> objectRow);
        List<Equipment> BuildObjects(List<Dictionary<string, object>> objectRows);
        SqlOperation GetCreateStatement(Equipment entityDTO);
        SqlOperation GetUpdateStatement(Equipment entityDTO);
        SqlOperation GetDeleteStatement(int equipmentID);
        SqlOperation GetRetrieveAllStatement();

    }
}

