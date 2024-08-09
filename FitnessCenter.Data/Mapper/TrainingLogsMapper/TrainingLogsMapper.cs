using FitnessCenter.Data.Dao;
using FitnessCenter.DTO.TrainingLogsDTO;
using System;
using System.Collections.Generic;

namespace FitnessCenter.Data.Mapper.TrainingLogsMapper
{
    public class TrainingLogsMapper : ITrainingLogsMapper
    {
        public TrainingLogs BuildTrainingLogsObject(Dictionary<string, object> objectRow)
        {
            var trainingLog = new TrainingLogs
            {
                TrainingLogID = objectRow.ContainsKey("TrainingLogID") ? Convert.ToInt32(objectRow["TrainingLogID"]) : 0,
                ClientID = objectRow.ContainsKey("ClientID") ? Convert.ToInt32(objectRow["ClientID"]) : 0,
                DateLogged = objectRow.ContainsKey("DateLogged") ? Convert.ToDateTime(objectRow["DateLogged"]) : DateTime.MinValue,
                SetsCompleted = objectRow.ContainsKey("SetsCompleted") ? Convert.ToInt32(objectRow["SetsCompleted"]) : 0,
                RepetitionsCompleted = objectRow.ContainsKey("RepetitionsCompleted") ? Convert.ToInt32(objectRow["RepetitionsCompleted"]) : 0,
                WeightUsed = objectRow.ContainsKey("WeightUsed") ? Convert.ToDecimal(objectRow["WeightUsed"]) : 0m,
                DurationInSeconds = objectRow.ContainsKey("DurationInSeconds") ? Convert.ToInt32(objectRow["DurationInSeconds"]) : 0,
                ExcerciseName = objectRow.ContainsKey("ExerciseName") ? objectRow["ExerciseName"].ToString() : string.Empty
            };

            return trainingLog;
        }

        public List<TrainingLogs> BuildTrainingLogsObjects(List<Dictionary<string, object>> objectRows)
        {
            var trainingLogs = new List<TrainingLogs>();
            foreach (var objectRow in objectRows) {
                trainingLogs.Add(BuildTrainingLogsObject(objectRow));
            }
            return trainingLogs;
        }

        public SqlOperation GetCreateTrainingLogsStatement(TrainingLogs entityDTO)
        {

            var operation = new SqlOperation
            {
                ProcedureName = "CreateTrainingLogs"
            };

            operation.AddVarcharParam("ClientID", entityDTO.ClientID.ToString());
            operation.AddDateTimeParam("DateLogged", entityDTO.DateLogged);
            operation.AddVarcharParam("ExerciseName", entityDTO.ExcerciseName);
            operation.AddVarcharParam("SetsCompleted", entityDTO.SetsCompleted.ToString());
            operation.AddVarcharParam("RepetitionsCompleted", entityDTO.RepetitionsCompleted.ToString());
            operation.AddVarcharParam("WeightUsed", entityDTO.WeightUsed.ToString());
            operation.AddVarcharParam("DurationInSeconds", entityDTO.DurationInSeconds.ToString());

            return operation;
        }

        public SqlOperation GetUpdateTrainingLogsStatement(TrainingLogs entityDTO)
        {
            
            throw new NotImplementedException();
        }

        public SqlOperation GetDeleteTrainingLogsStatement(int trainingLogsID)
        {
          
            throw new NotImplementedException();
        }

        public SqlOperation GetRetrieveAllTrainingLogsStatement()
        {
            
            throw new NotImplementedException();
        }

        public SqlOperation GetRetrieveTrainingLogsByUserIdStatement(int userId)
        {

            var operation = new SqlOperation
            {
                ProcedureName = "GetRetrieveTrainingLogsByUserId"
            };

            operation.AddVarcharParam("UserID", userId.ToString());
            return operation;
        }
    }
}
