using FitnessCenter.Data.Dao;
using FitnessCenter.DTO.RoutineDTO;
using System;
using System.Collections.Generic;

namespace FitnessCenter.Core
{
    public class RoutineManager
    {
        private readonly RoutineCrudFactory routineCrud = new RoutineCrudFactory();

        public Dictionary<string, string> CreateRoutine(Routine routine, 
            List<RoutineExercise> exercises, List<RoutineEquipment> equipment)
        {
            return routineCrud.Create(routine, exercises, equipment);
        }

        public Dictionary<string, string> UpdateRoutine(Routine routine, 
            List<RoutineExercise> exercises, List<RoutineEquipment> equipment)
        {
            var result = routineCrud.Update(routine);

            routineCrud.ClearExercises(routine.RoutineID);
            foreach (var exercise in exercises)
            {
                routineCrud.AddExercise(exercise);
            }

            routineCrud.ClearEquipment(routine.RoutineID);
            foreach (var equip in equipment)
            {
                routineCrud.AddEquipment(equip);
            }

            return result;
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

        public List<Routine> RetrieveByClient(int clientID)
        {
            return routineCrud.RetrieveByClient<Routine>(clientID);
        }
    }
}
