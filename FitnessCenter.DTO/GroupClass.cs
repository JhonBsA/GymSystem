using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenter.DTO
{
    public class GroupClass
    {
        public int ClassID { get; set; }
        public string? ClassName { get; set; }
        public int Capacity { get; set; }
        public DateTime Schedule { get; set; }
    }
}
