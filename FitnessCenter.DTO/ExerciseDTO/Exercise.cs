using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenter.DTO.ExerciseDTO
{
    public class Exercise
    {
        public int ExerciseID { get; set; }
        public int ExerciseTypeID { get; set; }
        public string? Name { get; set; }
    }
}
