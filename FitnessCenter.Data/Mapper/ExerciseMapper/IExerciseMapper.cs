using FitnessCenter.Data.Dao;
using FitnessCenter.DTO.ExerciseDTO;
using System.Collections.Generic;


namespace FitnessCenter.Data.Mapper.ExerciseMapper
{
    public interface IExerciseMapper
    {
        Exercise BuildObject(Dictionary<string, object> objectRow);
        List<Exercise> BuildObjects(List<Dictionary<string, object>> objectRows);
        SqlOperation GetCreateStatement(Exercise entityDTO);
        SqlOperation GetUpdateStatement(Exercise entityDTO);
        SqlOperation GetDeleteStatement(int exerciseID);
        SqlOperation GetRetrieveAllStatement();

    }
}
