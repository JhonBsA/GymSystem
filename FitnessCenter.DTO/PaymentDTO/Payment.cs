using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenter.DTO.PaymentDTO
{
    public class Payment : PaymentBaseClass
    {
        public int PaymentID { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public int PaymentMethodID { get; set; }
    }
}

