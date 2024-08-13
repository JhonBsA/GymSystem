using FitnessCenter.Data.Dao;
using FitnessCenter.DTO.PaymentDTO;
using System.Collections.Generic;

namespace FitnessCenter.Data.Mapper.PaymentMapper
{
    public interface IPaymentMapper
    {
        Payment BuildPaymentObject(Dictionary<string, object> objectRow);
        List<Payment> BuildPaymentObjects(List<Dictionary<string, object>> objectRows);
        UserPaymentMethod BuildUserPaymentMethodObject(Dictionary<string, object> objectRow);
        List<UserPaymentMethod> BuildUserPaymentMethodObjects(List<Dictionary<string, object>> objectRows);
        List<Payment> BuildUserPaymentObjects(List<Dictionary<string, object>> objectRows);
        SqlOperation GetCreatePaymentStatement(Payment entityDTO);
        SqlOperation GetUpdatePaymentStatement(Payment entityDTO);
        SqlOperation GetDeletePaymentStatement(int paymentID);
        SqlOperation GetRetrieveAllPaymentsStatement();
        SqlOperation GetCreateUserPaymentMethodStatement(UserPaymentMethod entityDTO);
        SqlOperation GetUpdateUserPaymentMethodStatement(UserPaymentMethod entityDTO);
        SqlOperation GetDeleteUserPaymentMethodStatement(int paymentMethodID);
        SqlOperation GetRetrieveAllUserPaymentMethodsStatement(int UserID);
        SqlOperation GetRetrievePaymentByUserIdStatement(int userId);
    }

}

