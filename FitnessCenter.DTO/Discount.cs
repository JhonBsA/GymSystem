using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenter.DTO
{
    public class Discount
    {
        public int DiscountID { get; set; }
        public string? DiscountType { get; set; }
        public decimal Percentage { get; set; }
        public string? Description { get; set; }
    }
}
