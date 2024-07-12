using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenter.DTO
{
    public class PersonalTrainingSession
    {
        public int SessionID { get; set; }
        public int ClientID { get; set; }
        public int TrainerID { get; set; }
        public DateTime ScheduledDate { get; set; }
        public int DurationInMinutes { get; set; }
        public decimal Cost { get; set; }
    }
}
