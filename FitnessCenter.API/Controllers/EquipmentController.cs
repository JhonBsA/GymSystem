using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FitnessCenter.Core;
using Microsoft.AspNetCore.Identity;
using FitnessCenter.DTO.EquipmentDTO;

namespace FitnessCenter.API.Controllers
{
    [EnableCors("NocheCorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentController : ControllerBase
    {

        private readonly EquipmentManager _equipmentManager;

        public EquipmentController()
        {
            _equipmentManager = new EquipmentManager();
        }

    }
}

