using FitnessCenter.Data.Dao;
using FitnessCenter.Data.Mapper.EquipmentMapper;
using FitnessCenter.DTO.EquipmentDTO;
using System.Collections.Generic;

namespace FitnessCenter.Data.Crud.EquipmentCRUD
{
    public class EquipmentCrudFactory : EquipmentCrudFactoryBase
    {
        private readonly EquipmentMapper _mapper;


        public EquipmentCrudFactory()
        {
            _mapper = new EquipmentMapper();
            dao = SqlDao.GetInstance();
        }

        public override Dictionary<string, string> Create(EquipmentBaseClass entityDTO)
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

        public override Dictionary<string, string> Update(EquipmentBaseClass entityDTO)
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

        public override Dictionary<string, string> Delete(EquipmentBaseClass entityDTO)
        {
            var operation = _mapper.GetDeleteStatement(entityDTO);
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

        public override List<EquipmentBaseClass> RetrieveAll()
        {
            throw new NotImplementedException();
        }
    }
}
