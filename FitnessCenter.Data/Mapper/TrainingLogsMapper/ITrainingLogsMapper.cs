using FitnessCenter.Data.Dao;
using FitnessCenter.DTO.TrainingLogsDTO;

namespace FitnessCenter.Data.Mapper.TrainingLogsMapper
{
    public interface ITrainingLogsMapper
    {
        TrainingLogs BuildTrainingLogsObject(Dictionary<string, object> objectRow);
        List<TrainingLogs> BuildTrainingLogsObjects(List<Dictionary<string, object>> objectRows);
        SqlOperation GetCreateTrainingLogsStatement(TrainingLogs entityDTO);
        SqlOperation GetUpdateTrainingLogsStatement(TrainingLogs entityDTO);
        SqlOperation GetDeleteTrainingLogsStatement(int trainingLogsID);
        SqlOperation GetRetrieveAllTrainingLogsStatement();
        SqlOperation GetRetrieveTrainingLogsByUserIdStatement(int userId);
    }
}
