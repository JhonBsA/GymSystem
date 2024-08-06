using FitnessCenter.DTO.PaymentDTO;
using FitnessCenter.Data.Crud.PayementCRUD;
using FitnessCenter.DTO.PaymentDTO.FitnessCenter.DTO.PaymentDTO;

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

        public Dictionary<string, string> DeleteUserPaymentMethod(int id)
        {
            var result = _paymentCrudFactory.Delete(id);
            return result;
        }

        public List<UserPaymentMethodResponse> GetAllUserPaymentMethods(int UserId)
        {
            var result = _paymentCrudFactory.GetAllUserPaymentMethod(UserId);
            return result;
        }

        public Dictionary<string, string> GetPaymentMethod(string displayPaymentMethod, int UserId)
        {
            var result = _paymentCrudFactory.GetPaymentMethod(displayPaymentMethod, UserId);
            return result;
        }

    }
}
