using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenter.DTO.PaymentDTO
{
    public class UserPaymentMethod : PaymentBaseClass
    {
        public int PaymentMethodID { get; set; }
        public string PaymentMethodType { get; set; }
        public string CreditCardNumber { get; set; }
        public DateTime? CreditCardExpiryDate { get; set; }
        public string PayPalEmail { get; set; }
        public string DisplayPaymentMethod { get; set; }
    }
}

