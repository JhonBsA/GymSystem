using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenter.DTO
{
    public class Appointment : AppointmentBaseClass
    { 
        public int AppointmentID { get; set; }
        public int ClientID { get; set; }
        public int TrainerID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int DurationInMinutes { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Notes { get; set; }
        public int? CalendarID { get; set; }
    }
}


