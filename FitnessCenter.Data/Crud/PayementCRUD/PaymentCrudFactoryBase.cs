using FitnessCenter.Data.Dao;
using FitnessCenter.DTO.PaymentDTO;

namespace FitnessCenter.Data.Crud.PayementCRUD
{
    public abstract class PaymentCrudFactoryBase
    {
        protected SqlDao dao;

        public abstract Dictionary<string, string> Create(Payment entityDTO);
        public abstract List<Payment> RetrieveAll(int userId);

        public abstract Dictionary<string, string> Update(Payment entityDTO);
        public abstract Dictionary<string, string> Delete(int id);

    }
}
