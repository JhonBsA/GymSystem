using FitnessCenter.Data.Dao;
using FitnessCenter.DTO.RoleDTO;
using System.Collections.Generic;

namespace FitnessCenter.Data.Crud.RoleCRUD
{
    public abstract class RoleCrudFactoryBase
    {
        protected SqlDao dao;

        public abstract Dictionary<string, string> Create(Role entityDTO);
        public abstract List<Role> RetrieveAll();
        public abstract Role RetrieveById(int id);
    }
}

