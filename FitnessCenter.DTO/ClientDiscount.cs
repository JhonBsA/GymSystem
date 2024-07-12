using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenter.DTO
{
    public class ClientDiscount
    {
        public int ClientDiscountID { get; set; }
        public int ClientID { get; set; }
        public int DiscountID { get; set; }
        public DateTime AppliedAt { get; set; }
    }
}
