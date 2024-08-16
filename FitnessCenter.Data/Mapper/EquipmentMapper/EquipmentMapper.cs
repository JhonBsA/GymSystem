using FitnessCenter.Data.Dao;
using FitnessCenter.DTO.EquipmentDTO;

namespace FitnessCenter.Data.Mapper.EquipmentMapper
{
    public class EquipmentMapper : IEquipmentMapper
    {
        public Equipment BuildObject(Dictionary<string, object> objectRow)
        {
            if (objectRow == null || objectRow.Count == 0)
            {
                throw new ArgumentException("objectRow is null or empty");
            }
            var equipment = new Equipment()
            {
                EquipmentID = Convert.ToInt32(objectRow["EquipmentID"]),
                Name = objectRow["Name"] as string,
                Type = objectRow["Type"] as string,
            };
            return equipment;
        }

        public List<Equipment> BuildObjects(List<Dictionary<string, object>> objectRows)
        {
            if (objectRows == null || objectRows.Count == 0)
            {
                throw new ArgumentException("objectRows is null or empty");
            }

            var equipments = new List<Equipment>();
            foreach (var objectRow in objectRows)
            {
                var equipment = BuildObject(objectRow);
                equipments.Add(equipment);
            }
            return equipments;
        }

        public SqlOperation GetCreateStatement(Equipment entityDTO)
        {
            var operation = new SqlOperation
            {
                ProcedureName = "CreateEquipment"
            };

            operation.AddVarcharParam("Name", entityDTO.Name);
            operation.AddVarcharParam("Type", entityDTO.Type);
            return operation;
        }

        public SqlOperation GetUpdateStatement(Equipment entityDTO)
        {
            var operation = new SqlOperation
            {
                ProcedureName = "UpdateEquipment"
            };

            operation.AddIntegerParam("EquipmentID", entityDTO.EquipmentID);
            operation.AddVarcharParam("Name", entityDTO.Name);
            operation.AddVarcharParam("Type", entityDTO.Type);
            return operation;
        }

        public SqlOperation GetDeleteStatement(int equipmentID)
        {
            var operation = new SqlOperation
            {
                ProcedureName = "DeleteEquipment"
            };

            operation.AddIntegerParam("EquipmentID", equipmentID);
            return operation;
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            var operation = new SqlOperation
            {
                ProcedureName = "GetAllEquipment"
            };
            return operation;
        }
    }
}
