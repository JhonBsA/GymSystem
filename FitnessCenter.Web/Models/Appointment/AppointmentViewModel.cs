namespace FitnessCenter.Web.Models.Appointment
{
    public class AppointmentViewModel
    {
        public int AppointmentID { get; set; }
        public string ClientID{ get; set; }
        public DateTime AppointmentDate { get; set; }
        public string TrainerID { get; set; }
        public string DurationInMinutes { get; set; }
        public string Notes { get; set; }
    }

}
