using FitnessCenter.Data.Dao;
using FitnessCenter.DTO.EquipmentDTO;
using System;
using System.Collections.Generic;

namespace FitnessCenter.Data.Mapper.EquipmentMapper
{
    public class EquipmentMapper : IEquipmentMapper
    {
        public EquipmentBaseClass BuildObject(Dictionary<string, object> objectRow)
        {
            var equipment = new Equipment
            {
                EquipmentID = (int)objectRow["EquipmentID"],
                Name = objectRow["Name"].ToString(),
                Type = objectRow["Type"].ToString(),
            };
            return equipment;
        }

        public List<EquipmentBaseClass> BuildObjects(List<Dictionary<string, object>> objectRows)
        {
            var equipments = new List<EquipmentBaseClass>();
            foreach (var row in objectRows)
            {
                equipments.Add(BuildObject(row));
            }
            return equipments;
        }

        public SqlOperation GetCreateStatement(EquipmentBaseClass entityDTO)
        {
            var operation = new SqlOperation
            {
                ProcedureName = "CreateEquipment"
            };

            var equipment = (Equipment)entityDTO;

            operation.AddVarcharParam("Name", equipment.Name);
            operation.AddVarcharParam("Type", equipment.Type);
            return operation;
        }

        public SqlOperation GetUpdateStatement(EquipmentBaseClass entityDTO)
        {
            var operation = new SqlOperation
            {
                ProcedureName = "UpdateEquipment"
            };

            var equipment = (Equipment)entityDTO;

            operation.AddIntegerParam("EquipmentID", equipment.EquipmentID);
            operation.AddVarcharParam("Name", equipment.Name);
            operation.AddVarcharParam("Type", equipment.Type);
            return operation;
        }

        public SqlOperation GetDeleteStatement(EquipmentBaseClass entityDTO)
        {
            var operation = new SqlOperation
            {
                ProcedureName = "DeleteEquipment"
            };

            var equipment = (Equipment)entityDTO;

            operation.AddIntegerParam("EquipmentID", equipment.EquipmentID);
            return operation;
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            var operation = new SqlOperation
            {
                ProcedureName = "RetrieveAllEquipment"
            };
            return operation;
        }
    }
}
