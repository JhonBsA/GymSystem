using FitnessCenter.Data.Dao;
using FitnessCenter.DTO.ExerciseTypeDTO;
using System.Collections.Generic;


namespace FitnessCenter.Data.Mapper.ExerciseTypeMapper
{
    public interface IExerciseTypeMapper
    {
        ExerciseType BuildObject(Dictionary<string, object> objectRow);
        List<ExerciseType> BuildObjects(List<Dictionary<string, object>> objectRows);
        SqlOperation GetCreateStatement(ExerciseType entityDTO);
        SqlOperation GetUpdateStatement(ExerciseType entityDTO);
        SqlOperation GetDeleteStatement(int exercisesID);
        SqlOperation GetRetrieveAllStatement();
    }
}
