using FitnessCenter.DTO.RoutineDTO;
using FitnessCenter.DTO.EquipmentDTO;
using FitnessCenter.Data.Dao;

namespace FitnessCenter.Data.Mapper.RoutineMapper
{
    public interface IRoutineMapper
    {
        SqlOperation GetCreateStatement(Routine routine, List<RoutineExerciseDetail> exerciseDetails);
        SqlOperation GetUpdateStatement(Routine routine);
        SqlOperation GetDeleteStatement(int routineID);
        SqlOperation GetRetrieveByIdStatement(int routineID);
        SqlOperation GetRetrieveAllStatement();
        SqlOperation GetRetrieveByClientStatement(int clientID);
        SqlOperation GetAddExerciseStatement(RoutineExercise exercise);
        SqlOperation GetClearExercisesStatement(int routineID);
        SqlOperation GetAddEquipmentStatement(RoutineEquipment equipment);
        SqlOperation GetClearEquipmentStatement(int routineID);
        T BuildObject<T>(Dictionary<string, object> row);
        List<T> BuildObjects<T>(List<Dictionary<string, object>> rows);
    }
}
