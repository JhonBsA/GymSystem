using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenter.DTO.EquipmentDTO
{
    public class Equipment : EquipmentBaseClass
    {
        public int EquipmentID { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
    }
}
