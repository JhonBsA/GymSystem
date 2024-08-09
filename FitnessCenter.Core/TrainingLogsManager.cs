using FitnessCenter.DTO.TrainingLogsDTO;
using FitnessCenter.Data.Crud.TrainingLogsCRUD;


namespace FitnessCenter.Core
{
    public class TrainingLogsManager
    {
        private readonly TrainingLogsCrudFactory _trainingLogsCrudFactory;
        public TrainingLogsManager()
        {
            _trainingLogsCrudFactory = new TrainingLogsCrudFactory();
        }

        public Dictionary<string, string> CreateTrainingLogs(TrainingLogs trainingLogs)
        {
            var result = _trainingLogsCrudFactory.Create(trainingLogs);
            return result;
        }
        public List<TrainingLogs> GetTrainingLogsByUserId(int UserId)
        {
            var result = _trainingLogsCrudFactory.RetrieveAll(UserId);
            return result;
        }
    }
}
