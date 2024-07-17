using FitnessCenter.Data.Dao;
using FitnessCenter.DTO;
using System.Collections.Generic;

namespace FitnessCenter.Data.Crud
{
    public abstract class CrudFactory
    {
        protected SqlDao dao;

        public abstract Dictionary<string, string> Create(BaseClass entityDTO);
        public abstract Dictionary<string, string> Update(BaseClass entityDTO);
        public abstract Dictionary<string, string> Delete(BaseClass entityDTO);
        public abstract List<T> RetrieveAll<T>();
        public abstract BaseClass RetrieveById(int id);
    }
}
