using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using FitnessCenter.Core;
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

        [HttpPost]
        [Route("CreateEquipment")]
        public IActionResult CreateEquipment(Equipment equipment)
        {
            var result = _equipmentManager.CreateEquipment(equipment);
            return Ok(result);
        }

        [HttpPut]
        [Route("UpdateEquipment")]
        public IActionResult UpdateEquipment(Equipment equipment)
        {
            var result = _equipmentManager.UpdateEquipment(equipment);
            return Ok(result);
        }

        [HttpDelete]
        [Route("DeleteEquipment")]
        public IActionResult DeleteEquipment(int equipmentID)
        {
            var result = _equipmentManager.DeleteEquipment(equipmentID);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetAllEquipments")]
        public IActionResult GetAllEquipments()
        {
            var result = _equipmentManager.GetAllEquipments();
            return Ok(result);
        }

    }
}

