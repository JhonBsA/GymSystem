using FitnessCenter.Data.Dao;
using FitnessCenter.DTO.RoutineDTO;
using System;
using System.Collections.Generic;

namespace FitnessCenter.Core
{
    public class RoutineManager
    {
        private readonly RoutineCrudFactory routineCrud = new RoutineCrudFactory();

        public Dictionary<string, string> CreateRoutine(Routine routine, List<RoutineExerciseDetail> exerciseDetails)
        {
            return routineCrud.Create(routine, exerciseDetails);
        }


        public Dictionary<string, string> UpdateRoutine(Routine routine, 
            List<RoutineExercise> exercises, List<RoutineEquipment> equipment)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, string> DeleteRoutine(int routineID)
        {
            return routineCrud.Delete(routineID);
        }

        public Routine GetRoutine(int routineID)
        {
            return routineCrud.Retrieve<Routine>(routineID);
        }

        public List<Routine> RetrieveAllRoutines()
        {
            return routineCrud.RetrieveAll<Routine>();
        }

        public List<RoutineWithID> RetrieveByClient(int userId)
        {
            return routineCrud.RetrieveByClient(userId);
        }
        

    }
}
