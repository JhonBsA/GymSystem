using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenter.DTO.PaymentDTO
{
    namespace FitnessCenter.DTO.PaymentDTO
    {
        public class UserPaymentMethodResponse : PaymentBaseClass
        {
            public string PaymentMethodType { get; set; }
            public string DisplayPaymentMethod { get; set; }
            public string PayPalEmail { get; set; }
        }
    }

}
