using FitnessCenter.DTO.PaymentDTO;
using FitnessCenter.Data.Crud.PayementCRUD;

namespace FitnessCenter.Core
{
    public class PaymentManager
    {
        private readonly PaymentCrudFactory _paymentCrudFactory;
        public PaymentManager()
        {
            _paymentCrudFactory = new PaymentCrudFactory();
        }

        public Dictionary<string, string> CreatePayment(Payment payment)
        {
            var result = _paymentCrudFactory.Create(payment);
            return result;
        }

        public Dictionary<string, string> AddUserPaymentMethod(UserPaymentMethod payment) 
        {
            var result = _paymentCrudFactory.AddUserPaymentMethod(payment);
            return result;
        }

    }
}
