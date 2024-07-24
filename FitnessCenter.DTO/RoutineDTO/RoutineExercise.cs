using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenter.DTO.RoutineDTO
{
    public class RoutineExercise
    {
        public int RoutineExerciseID { get; set; }
        public int RoutineID { get; set; }
        public int ExerciseID { get; set; }
        public int Sets { get; set; }
        public int Repetitions { get; set; }
        public decimal Weight { get; set; }
        public int DurationInSeconds { get; set; }
        public int AmrapTimeLimitInSeconds { get; set; }
        public int AmrapRepetitions { get; set; }
    }
}
