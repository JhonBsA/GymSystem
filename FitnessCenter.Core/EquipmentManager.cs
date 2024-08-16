using FitnessCenter.Data.Crud.EquipmentCRUD;
using FitnessCenter.DTO.EquipmentDTO;

namespace FitnessCenter.Core
{
    public class EquipmentManager
    {
        private readonly EquipmentCrudFactory _equipmentCrud;

        public EquipmentManager()
        {
            _equipmentCrud = new EquipmentCrudFactory();
        }

        public Dictionary<string, string> CreateEquipment(Equipment equipment)
        {
            var result = _equipmentCrud.Create(equipment);
            return result;
        }

        public Dictionary<string, string> UpdateEquipment(Equipment equipment)
        {
            var result = _equipmentCrud.Update(equipment);
            return result;
        }

        public Dictionary<string, string> DeleteEquipment(int equipmentID)
        {
            var result = _equipmentCrud.Delete(equipmentID);
            return result;
        }

        public List<Equipment> GetAllEquipments()
        {
            var result = _equipmentCrud.RetrieveAll();
            return result;
        }
    }
}
