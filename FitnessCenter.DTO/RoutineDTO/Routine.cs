using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenter.DTO.RoutineDTO
{
    public class Routine
    {
        public int RoutineID { get; set; }
        public int ClientID { get; set; }
        public int TrainerID { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
