using FitnessCenter.DTO.RoutineDTO;
using System.Collections.Generic;

namespace FitnessCenter.Core
{
    public class RoutineRequest
    {
        public Routine Routine { get; set; }
        public List<RoutineExercise> Exercises { get; set; } = new List<RoutineExercise>();
        public List<RoutineEquipment> Equipment { get; set; } = new List<RoutineEquipment>();
    }
}

