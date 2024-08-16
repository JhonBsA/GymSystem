﻿using FitnessCenter.Data.Dao;
using FitnessCenter.Data.Mapper.EquipmentMapper;
using FitnessCenter.DTO.EquipmentDTO;

namespace FitnessCenter.Data.Crud.EquipmentCRUD
{
    public class EquipmentCrudFactory
    {
        private readonly EquipmentMapper _mapper;
        private readonly SqlDao dao;

        public EquipmentCrudFactory()
        {
            _mapper = new EquipmentMapper();
            dao = SqlDao.GetInstance();
        }

        public Dictionary<string, string> Create(Equipment entityDTO)
        {
            var operation = _mapper.GetCreateStatement(entityDTO);
            var result = dao.ExecuteStoredProcedureWithResult(operation);
            if (result.Count == 0)
            {
                throw new Exception("No response from stored procedure.");
            }
            var firstRow = result[0];
            var response = new Dictionary<string, string>();
            foreach (var key in firstRow.Keys)
            {
                response[key] = firstRow[key].ToString();
            }
            return response;
        }

        public Dictionary<string, string> Update(Equipment entityDTO)
        {
            var operation = _mapper.GetUpdateStatement(entityDTO);
            var result = dao.ExecuteStoredProcedureWithResult(operation);
            if (result.Count == 0)
            {
                throw new Exception("No response from stored procedure.");
            }
            var firstRow = result[0];
            var response = new Dictionary<string, string>();
            foreach (var key in firstRow.Keys)
            {
                response[key] = firstRow[key].ToString();
            }
            return response;
        }

        public Dictionary<string, string> Delete(int equipmentID)
        {
            SqlOperation operation = _mapper.GetDeleteStatement(equipmentID);
            var result = dao.ExecuteStoredProcedureWithResult(operation);
            if (result.Count == 0)
            {
                throw new Exception("No response from stored procedure.");
            }
            var firstRow = result[0];
            var response = new Dictionary<string, string>();
            foreach (var key in firstRow.Keys)
            {
                response[key] = firstRow[key].ToString();
            }
            return response;
        }

        public List<Equipment> RetrieveAll()
        {
            SqlOperation operation = _mapper.GetRetrieveAllStatement();
            var result = dao.ExecuteStoredProcedureWithResult(operation);
            if (result.Count == 0)
            {
                throw new Exception("No response from stored procedure.");
            }
            var equipment = _mapper.BuildObjects(result);
            return equipment;
        }
    }
}
