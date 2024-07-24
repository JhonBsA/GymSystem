using FitnessCenter.Data.Dao;
using FitnessCenter.Data.Crud.EquipmentCRUD;
using FitnessCenter.DTO.EquipmentDTO;

namespace FitnessCenter.Core
{
    public class EquipmentManager
    {
        readonly EquipmentCrudFactory equipmentCrud = new EquipmentCrudFactory();
    }
}
