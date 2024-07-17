using FitnessCenter.DTO;
using System.Collections.Generic;

namespace FitnessCenter.Data.Mapper
{
    public interface IAppointmentMapper
    {
        AppointmentBaseClass BuildObject(Dictionary<string, object> objectRow);
        List<AppointmentBaseClass> BuildObjects(List<Dictionary<string, object>> objectRows);
    }
}
