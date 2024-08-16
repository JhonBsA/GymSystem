using FitnessCenter.Data.Dao;
using FitnessCenter.Data.Mapper.ExerciseTypeMapper;
using FitnessCenter.DTO.ExerciseTypeDTO;


namespace FitnessCenter.Data.Crud.ExerciseTypeCRUD
{
    public class ExerciseTypeCrudFactory
    {
        private readonly ExerciseTypeMapper _mapper;
        private readonly SqlDao dao;

        public ExerciseTypeCrudFactory()
        {
            _mapper = new ExerciseTypeMapper();
            dao = SqlDao.GetInstance();
        }

        public Dictionary<string, string> Create(ExerciseType entityDTO)
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

        public Dictionary<string, string> Update(ExerciseType entityDTO)
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

        public Dictionary<string, string> Delete(int exerciseTypeID)
        {
            var operation = _mapper.GetDeleteStatement(exerciseTypeID);
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

        public List<ExerciseType> RetrieveAll()
        {
            SqlOperation operation = _mapper.GetRetrieveAllStatement();
            var result = dao.ExecuteStoredProcedureWithResult(operation);
            if (result.Count == 0)
            {
                throw new Exception("No response from stored procedure.");
            }

            var exerciseType = _mapper.BuildObjects(result);

            return exerciseType;
        }
    }
}
