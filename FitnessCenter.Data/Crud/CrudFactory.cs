using FitnessCenter.Data.Dao;
using FitnessCenter.DTO;


namespace FitnessCenter.Data.Crud
{
    public abstract class CrudFactory
    {
        protected SqlDao dao;
        public abstract void Create(BaseClass entityDTO);
        public abstract void Update(BaseClass entityDTO);
        public abstract void Delete(BaseClass entityDTO);
        public abstract List<T> RetrieveAll<T>();
        public abstract BaseClass RetrieveById(int id);
    }
}
