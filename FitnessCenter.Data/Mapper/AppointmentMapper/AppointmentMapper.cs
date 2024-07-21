using Azure;
using FitnessCenter.Data.Dao;
using FitnessCenter.DTO.AppointmentDTO;
using System;
using System.Collections.Generic;

namespace FitnessCenter.Data.Mapper.AppointmentMapper
{
    public class AppointmentMapper : IAppointmentMapper
    {
        public AppointmentBaseClass BuildObject(Dictionary<string, object> objectRow)
        {
            var appointment = new Appointment
            {
                AppointmentID = objectRow.ContainsKey("AppointmentID") ? Convert.ToInt32(objectRow["AppointmentID"]) : 0,
                ClientID = Convert.ToInt32(objectRow["ClientID"]),
                TrainerID = Convert.ToInt32(objectRow["TrainerID"]),
                AppointmentDate = Convert.ToDateTime(objectRow["AppointmentDate"]),
                DurationInMinutes = Convert.ToInt32(objectRow["DurationInMinutes"]),
                CreatedAt = Convert.ToDateTime(objectRow["CreatedAt"]),
                Notes = objectRow.ContainsKey("Notes") ? objectRow["Notes"].ToString() : null,
                CalendarID = objectRow.ContainsKey("CalendarID") ? Convert.ToInt32(objectRow["CalendarID"]) : 0,
                ClientName = objectRow.ContainsKey("ClientName") ? objectRow["ClientName"].ToString() : string.Empty,
                TrainerName = objectRow.ContainsKey("TrainerName") ? objectRow["TrainerName"].ToString() : string.Empty
            };
            return appointment;
        }


        public List<Appointment> BuildObjects(List<Dictionary<string, object>> objectRows)
        {
            var appointments = new List<Appointment>(); 
            foreach (var row in objectRows)
            {
                appointments.Add((Appointment)BuildObject(row));
            }
            return appointments;
        }

        public SqlOperation GetCreateStatement(AppointmentBaseClass entityDTO)
        {
            var operation = new SqlOperation
            {
                ProcedureName = "CreateAppointment"
            };

            var appointment = (Appointment)entityDTO;

            operation.AddVarcharParam("ClientName", appointment.ClientName);
            operation.AddVarcharParam("TrainerName", appointment.TrainerName);
            operation.AddDateTimeParam("AppointmentDate", appointment.AppointmentDate);
            operation.AddIntegerParam("DurationInMinutes", appointment.DurationInMinutes);
            operation.AddDateTimeParam("CreatedAt", appointment.CreatedAt);
            operation.AddVarcharParam("Notes", appointment.Notes);
            return operation;
        }

        public SqlOperation GetUpdateStatement(AppointmentBaseClass entityDTO)
        {
            var operation = new SqlOperation
            {
                ProcedureName = "UpdateAppointment"
            };

            var appointment = (Appointment)entityDTO;

            operation.AddIntegerParam("AppointmentID", appointment.AppointmentID);
            operation.AddIntegerParam("ClientID", appointment.ClientID);
            operation.AddIntegerParam("TrainerID", appointment.TrainerID);
            operation.AddDateTimeParam("AppointmentDate", appointment.AppointmentDate);
            operation.AddIntegerParam("DurationInMinutes", appointment.DurationInMinutes);
            operation.AddVarcharParam("Notes", appointment.Notes);
            return operation;
        }

        public SqlOperation GetDeleteStatement(int appointmentID)
        {
            var operation = new SqlOperation
            {
                ProcedureName = "DeleteAppointment"
            };

            operation.AddIntegerParam("AppointmentID", appointmentID);
            return operation;
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            var operation = new SqlOperation
            {
                ProcedureName = "GetAllAppointments"
            };
            return operation;
        }

        public SqlOperation GetRetrieveByIdStatement(int appointmentID)
        {
            var operation = new SqlOperation
            {
                ProcedureName = "GetAppointmentById"
            };

            operation.AddIntegerParam("AppointmentID", appointmentID);
            return operation;
        }

        public SqlOperation GetRetrieveByDateRangeStatement(DateTime startDate, DateTime endDate)
        {
            var operation = new SqlOperation
            {
                ProcedureName = "RetrieveAppointmentsByDateRange"
            };

            operation.AddDateTimeParam("StartDate", startDate);
            operation.AddDateTimeParam("EndDate", endDate);
            return operation;
        }
    }
}
