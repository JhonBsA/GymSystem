using FitnessCenter.Data.Dao;
using FitnessCenter.DTO.ExerciseDTO;

namespace FitnessCenter.Data.Mapper.ExerciseMapper
{
    public class ExerciseMapper : IExerciseMapper
    {
        public Exercise BuildObject(Dictionary<string, object> objectRow)
        {
            var exercise = new Exercise()
            {
                ExerciseID = (int)objectRow["ExerciseID"],
                Name = objectRow["Name"].ToString(),
                ExerciseTypeID = (int)objectRow["ExerciseTypeID"]
            };
            return exercise;
        }

        public List<Exercise> BuildObjects(List<Dictionary<string, object>> objectRows)
        {
            var exercises = new List<Exercise>();
            foreach (var objectRow in objectRows)
            {
                var exercise = BuildObject(objectRow);
                exercises.Add(exercise);
            }
            return exercises;
        }

        public SqlOperation GetCreateStatement(Exercise entityDTO)
        {
            var operation = new SqlOperation
            {
                ProcedureName = "CreateExercise"
            };

            operation.AddVarcharParam("Name", entityDTO.Name);
            operation.AddIntegerParam("ExerciseTypeID", entityDTO.ExerciseTypeID);
            return operation;
        }

        public SqlOperation GetUpdateStatement(Exercise entityDTO)
        {
            var operation = new SqlOperation
            {
                ProcedureName = "UpdateExercise"
            };

            operation.AddIntegerParam("ExerciseID", entityDTO.ExerciseID);
            operation.AddVarcharParam("Name", entityDTO.Name);
            operation.AddIntegerParam("ExerciseTypeID", entityDTO.ExerciseTypeID);
            return operation;
        }

        public SqlOperation GetDeleteStatement(int exerciseID)
        {
            var operation = new SqlOperation
            {
                ProcedureName = "DeleteExercise"
            };

            operation.AddIntegerParam("ExerciseID", exerciseID);
            return operation;
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            var operation = new SqlOperation
            {
                ProcedureName = "GetAllExercises"
            };
            return operation;
        }
    }
}
