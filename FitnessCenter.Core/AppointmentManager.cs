using FitnessCenter.Data.Dao;
using FitnessCenter.Data.Crud.AppointmentCRUD;
using FitnessCenter.DTO.AppointmentDTO;


namespace FitnessCenter.Core
{
    public class AppointmentManager
    {
        readonly AppointmentCrudFactory appointmentCrud = new AppointmentCrudFactory();
        
        public Dictionary<string, string> CreateAppointment(Appointment appointment)
        {

            var result = appointmentCrud.Create(appointment);
            return result;
        }
        public Dictionary<string, string> UpdateAppointment(int appointmentID, int clientID, int trainerID,
            DateTime appointmentDate, int durationInMinutes, string notes)
        {
            var appointment = new Appointment
            {
                AppointmentID = appointmentID,
                ClientID = clientID,
                TrainerID = trainerID,
                AppointmentDate = appointmentDate,
                DurationInMinutes = durationInMinutes,
                Notes = notes
            };

            var result = appointmentCrud.Update(appointment);
            return result;
        }

        public Dictionary<string, string> DeleteAppointment(int appointmentID) {
            return appointmentCrud.Delete(appointmentID);
        }
        public List<Appointment> RetrieveAllAppointments()
        {
            return appointmentCrud.RetrieveAll<Appointment>();
        }

        public List<Appointment> RetrieveByDateRange(DateTime startDate, DateTime endDate)
        {
            return appointmentCrud.RetrieveByDateRange(startDate, endDate);
        }

        public DateTime GetLastAppointmentDate()
        {
            return appointmentCrud.RetrieveLastAppointmentDate();
        }
    }
}
