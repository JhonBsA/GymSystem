using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenter.DTO.MeasurementDTO
{
    public class Measurement
    {
        public int MeasurementID { get; set; }
        public string Email { get; set; }
        public int TrainerID { get; set; }
        public decimal Weight { get; set; }
        public decimal Height { get; set; }
        public decimal BodyFatPercentage { get; set; }
        public int Age { get; set; }
        public string? Gender { get; set; }
        public DateTime MeasuredAt { get; set; }
    }
}
