using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenter.DTO
{
    public class ClassReservation
    {
        public int ReservationID { get; set; }
        public int ClassID { get; set; }
        public int ClientID { get; set; }
        public DateTime ReservedAt { get; set; }
    }
}
