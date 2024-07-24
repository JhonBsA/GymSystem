using FitnessCenter.Data.Dao;
using FitnessCenter.DTO.EquipmentDTO;
using System.Collections.Generic;

namespace FitnessCenter.Data.Mapper.EquipmentMapper
{
    public interface IEquipmentMapper
    {
        EquipmentBaseClass BuildObject(Dictionary<string, object> objectRow);
        List<EquipmentBaseClass> BuildObjects(List<Dictionary<string, object>> objectRows);
        SqlOperation GetCreateStatement(EquipmentBaseClass entityDTO);
        SqlOperation GetUpdateStatement(EquipmentBaseClass entityDTO);
        SqlOperation GetDeleteStatement(EquipmentBaseClass entityDTO);
        SqlOperation GetRetrieveAllStatement();

    }
}

