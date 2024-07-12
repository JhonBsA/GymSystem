using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenter.DTO
{
    public class TrainingLogs
    {
        public int TrainingLogID { get; set; }
        public int ClientID { get; set; }
        public int RoutineExerciseID { get; set; }
        public DateTime DateLogged { get; set; }
        public int SetsCompleted { get; set; }
        public int RepetitionsCompleted { get; set; }
        public decimal WeightUsed { get; set; }
        public int DurationInSeconds { get; set; }
    }
}
