using FitnessCenter.Data.Dao;
using FitnessCenter.DTO.ExerciseTypeDTO;


namespace FitnessCenter.Data.Mapper.ExerciseTypeMapper
{
    public class ExerciseTypeMapper : IExerciseTypeMapper
    {
        public ExerciseType BuildObject(Dictionary<string, object> objectRow)
        {
            var exerciseType = new ExerciseType()
            {
                ExerciseTypeID = (int)objectRow["ExerciseTypeID"],
                TypeName = objectRow["TypeName"].ToString()
            };
            return exerciseType;
        }

        public List<ExerciseType> BuildObjects(List<Dictionary<string, object>> objectRows)
        {
            var exerciseTypes = new List<ExerciseType>();
            foreach (var row in objectRows)
            {
                exerciseTypes.Add(BuildObject(row));
            }
            return exerciseTypes;
        }

        public SqlOperation GetCreateStatement(ExerciseType entityDTO)
        {
            var operation = new SqlOperation
            {
                ProcedureName = "CreateExerciseType"
            };

            operation.AddVarcharParam("TypeName", entityDTO.TypeName);
            return operation;
        }

        public SqlOperation GetUpdateStatement(ExerciseType entityDTO)
        {
            var operation = new SqlOperation
            {
                ProcedureName = "UpdateExerciseType"
            };

            operation.AddIntegerParam("ExerciseTypeID", entityDTO.ExerciseTypeID);
            operation.AddVarcharParam("TypeName", entityDTO.TypeName);
            return operation;
        }

        public SqlOperation GetDeleteStatement(int exerciseTypeID)
        {
            var operation = new SqlOperation
            {
                ProcedureName = "DeleteExerciseType"
            };

            operation.AddIntegerParam("ExerciseTypeID", exerciseTypeID);
            return operation;
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            var operation = new SqlOperation
            {
                ProcedureName = "GetAllExerciseTypes"
            };
            return operation;
        }
    }
}
