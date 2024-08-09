using FitnessCenter.Data.Dao;
using FitnessCenter.DTO.TrainingLogsDTO;
using FitnessCenter.Data.Mapper.TrainingLogsMapper;
using FitnessCenter.DTO.PaymentDTO.FitnessCenter.DTO.PaymentDTO;
using FitnessCenter.Data.Mapper.PaymentMapper;

namespace FitnessCenter.Data.Crud.TrainingLogsCRUD
{
    public class TrainingLogsCrudFactory : TrainingLogsCrudFactoryBase
    {
        private TrainingLogsMapper mapper;
        private readonly SqlDao dao;

        public TrainingLogsCrudFactory()
        {
            mapper = new TrainingLogsMapper();
            dao = SqlDao.GetInstance();
        }
        public override Dictionary<string, string> Create(TrainingLogs entityDTO)
        {
            SqlOperation operation = mapper.GetCreateTrainingLogsStatement(entityDTO);
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

        public override List<TrainingLogs> RetrieveAll(int userId)
        {

            SqlOperation operation = mapper.GetRetrieveTrainingLogsByUserIdStatement(userId);
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

            var trainingLogs = mapper.BuildTrainingLogsObjects(result);
            return trainingLogs;

        }
    }
}
