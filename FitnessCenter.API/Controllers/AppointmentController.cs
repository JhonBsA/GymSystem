using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FitnessCenter.Core;
using Microsoft.AspNetCore.Identity;
using FitnessCenter.DTO.AppointmentDTO;
using Microsoft.Data.SqlClient;

namespace FitnessCenter.API.Controllers
{
    [EnableCors("NocheCorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly AppointmentManager _appointmentManager;

        public AppointmentController()
        {
            _appointmentManager = new AppointmentManager();
        }

        [HttpPost]
        [Route("CreateAppointment")]
        public IActionResult CreateAppointment([FromBody] Appointment appointment)
        {
            var result = _appointmentManager.CreateAppointment(appointment);
            return Ok(result);
        }

        [HttpGet]
        [Route("RetrieveByDateRange")]
        public IActionResult RetrieveByDateRange(DateTime startDate, DateTime endDate)
        {
            var result = _appointmentManager.RetrieveByDateRange(startDate, endDate);
            return Ok(result);
        }

        //[HttpPost]
        //[Route("UpdateAppointment")]
        //public IActionResult UpdateAppointment(int appointmentID, int clientID, int trainerID, 
        //    DateTime appointmentDate, int durationInMinutes, string notes)
        //{
        //    var result = _appointmentManager.UpdateAppointment(appointmentID, clientID, trainerID,
        //        appointmentDate, durationInMinutes, notes);
        //    return Ok(result);
        //}

        [HttpPost]
        [Route("UpdateAppointment")]
        public IActionResult UpdateAppointment(Appointment appointment)
        {
            var result = _appointmentManager.UpdateAppointment(appointment);
            return Ok(result);
        }

        [HttpDelete]
        [Route("DeleteAppointment")]
        public IActionResult DeleteAppointment(int appointmentID)
        {
            var result = _appointmentManager.DeleteAppointment(appointmentID);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetLastAppointmentDate")]
        public IActionResult GetLastAppointmentDate()
        {
            var lastAppointmentDate = _appointmentManager.GetLastAppointmentDate();
            return Ok(lastAppointmentDate);
        }
       

        [HttpGet]
        [Route("GetAppointmentById")]
        public IActionResult GetAppointmentById(int appointmentID)
        {
            var result = _appointmentManager.GetAppointmentById(appointmentID);
            return Ok(result);
        }

    }
}
