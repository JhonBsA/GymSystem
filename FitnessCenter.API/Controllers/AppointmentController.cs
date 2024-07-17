using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FitnessCenter.DTO;
using FitnessCenter.Core;

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
    }
}
