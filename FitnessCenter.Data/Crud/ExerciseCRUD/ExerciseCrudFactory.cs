using FitnessCenter.Data.Dao;
using FitnessCenter.Data.Mapper.ExerciseMapper;
using FitnessCenter.DTO.ExerciseDTO;


namespace FitnessCenter.Data.Crud.ExerciseCRUD
{
    public class ExerciseCrudFactory
    {
        private readonly ExerciseMapper _mapper;
        private readonly SqlDao dao;

        public ExerciseCrudFactory()
        {
            _mapper = new ExerciseMapper();
            dao = SqlDao.GetInstance();
        }

        public Dictionary<string, string> Create(Exercise entityDTO)
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

        public Dictionary<string, string> Update(Exercise entityDTO)
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

        public Dictionary<string, string> Delete(int exerciseID)
        {
            var operation = _mapper.GetDeleteStatement(exerciseID);
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

        public List<Exercise> RetrieveAll()
        {
            SqlOperation operation = _mapper.GetRetrieveAllStatement();
            var result = dao.ExecuteStoredProcedureWithResult(operation);
            if (result.Count == 0)
            {
                throw new Exception("No response from stored procedure.");
            }

            var exercise = _mapper.BuildObjects(result);

            return exercise;
        }
    }
}
