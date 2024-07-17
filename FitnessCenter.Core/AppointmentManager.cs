using FitnessCenter.DTO;
using FitnessCenter.Data.Dao;
using FitnessCenter.Data.Crud.AppointmentCRUD;


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
        public void UpdateAppointment(Appointment appointment) {
            appointmentCrud.Update(appointment);
        }
        public void DeleteAppointment(Appointment appointment) {
            appointmentCrud.Delete(appointment);
        }
        public List<Appointment> RetrieveAllAppointments()
        {
            return appointmentCrud.RetrieveAll<Appointment>();
        }
    }
}
