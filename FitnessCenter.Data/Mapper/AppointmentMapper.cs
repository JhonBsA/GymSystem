using FitnessCenter.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace FitnessCenter.Data.Mapper
{
    public class AppointmentMapper : IObjectMapper
    {
        public BaseClass BuildObject(Dictionary<string, object> objectRow)
        {
            var appointment = new Appointment
            {
                AppointmentID = Convert.ToInt32(objectRow["AppointmentID"]),
                ClientID = Convert.ToInt32(objectRow["ClientID"]),
                TrainerID = Convert.ToInt32(objectRow["TrainerID"]),
                AppointmentDate = Convert.ToDateTime(objectRow["AppointmentDate"]),
                DurationInMinutes = Convert.ToInt32(objectRow["DurationInMinutes"]),
                CreatedAt = Convert.ToDateTime(objectRow["CreatedAt"]),
                Notes = objectRow.ContainsKey("Notes") ? objectRow["Notes"].ToString() : null,
                CalendarID = objectRow.ContainsKey("CalendarID") ? Convert.ToInt32(objectRow["CalendarID"]) : (int?)null
            };

            return appointment;
        }

        public List<BaseClass> BuildObjects(List<Dictionary<string, object>> objectRows)
        {
            var appointments = new List<BaseClass>();

            foreach (var row in objectRows)
            {
                appointments.Add(BuildObject(row));
            }

            return appointments;
        }
    }
}
