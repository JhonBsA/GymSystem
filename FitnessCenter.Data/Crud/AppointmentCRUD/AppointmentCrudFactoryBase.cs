using FitnessCenter.Data.Dao;
using FitnessCenter.DTO;
using System.Collections.Generic;

namespace FitnessCenter.Data.Crud
{
    public abstract class AppointmentCrudFactoryBase
    {
        protected SqlDao dao;

        public abstract Dictionary<string, string> Create(AppointmentBaseClass entityDTO);
        public abstract Dictionary<string, string> Update(AppointmentBaseClass entityDTO);
        public abstract Dictionary<string, string> Delete(AppointmentBaseClass entityDTO);
        public abstract List<T> RetrieveAll<T>();
        public abstract AppointmentBaseClass RetrieveById(int id);
    }
}
