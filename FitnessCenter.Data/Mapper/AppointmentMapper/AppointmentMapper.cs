using Azure;
using FitnessCenter.Data.Dao;
using FitnessCenter.DTO;
using System;
using System.Collections.Generic;

namespace FitnessCenter.Data.Mapper.AppointmentMapper
{
   // public class AppointmentMapper : IAppointmentMapper
   // {
        //    public AppointmentBaseClass BuildObject(Dictionary<string, object> objectRow)
        //    {
        //        //var appointment = new Appointment
        //        //{
        //        //    AppointmentID = objectRow.ContainsKey("AppointmentID") ? Convert.ToInt32(objectRow["AppointmentID"]) : 0,
        //        //    ClientID = Convert.ToInt32(objectRow["ClientID"]),
        //        //    TrainerID = Convert.ToInt32(objectRow["TrainerID"]),
        //        //    AppointmentDate = Convert.ToDateTime(objectRow["AppointmentDate"]),
        //        //    DurationInMinutes = Convert.ToInt32(objectRow["DurationInMinutes"]),
        //        //    CreatedAt = Convert.ToDateTime(objectRow["CreatedAt"]),
        //        //    Notes = objectRow.ContainsKey("Notes") ? objectRow["Notes"].ToString() : null,
        //        //    CalendarID = objectRow.ContainsKey("CalendarID") ? Convert.ToInt32(objectRow["CalendarID"]) : null
        //        //};
        //        //return appointment;
        //    }

        //    public List<AppointmentBaseClass> BuildObjects(List<Dictionary<string, object>> objectRows)
        //    {
        //        var appointments = new List<AppointmentBaseClass>();
        //        foreach (var row in objectRows)
        //        {
        //            appointments.Add(BuildObject(row));
        //        }
        //        return appointments;
        //    }

        //    public SqlOperation GetCreateStatement(AppointmentBaseClass entityDTO)
        //    {
        //        var operation = new SqlOperation
        //        {
        //            ProcedureName = "CreateAppointment"
        //        };

        //        var appointment = (Appointment)entityDTO;

        //        operation.AddIntegerParam("ClientID", appointment.ClientID);
        //        operation.AddIntegerParam("TrainerID", appointment.TrainerID);
        //        operation.AddDateTimeParam("AppointmentDate", appointment.AppointmentDate);
        //        operation.AddIntegerParam("DurationInMinutes", appointment.DurationInMinutes);
        //        operation.AddDateTimeParam("CreatedAt", appointment.CreatedAt);
        //        operation.AddVarcharParam("Notes", appointment.Notes);
        //        return operation;
        //    }
        //}

    }
//}
