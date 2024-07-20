using FitnessCenter.Data.Dao;
using FitnessCenter.DTO.AppointmentDTO;

namespace FitnessCenter.Data.Mapper.AppointmentMapper
{
    public interface IAppointmentMapper
    {
        AppointmentBaseClass BuildObject(Dictionary<string, object> objectRow);
        List<Appointment> BuildObjects(List<Dictionary<string, object>> objectRows);
        SqlOperation GetCreateStatement(AppointmentBaseClass entityDTO);
        SqlOperation GetUpdateStatement(AppointmentBaseClass entityDTO);
        SqlOperation GetDeleteStatement(int appointmentID);
        SqlOperation GetRetrieveAllStatement();
        SqlOperation GetRetrieveByIdStatement(int appointmentID);
        SqlOperation GetRetrieveByDateRangeStatement(DateTime startDate, DateTime endDate);
    }
}