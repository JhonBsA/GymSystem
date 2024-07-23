using FitnessCenter.Data.Dao;
using FitnessCenter.DTO.EquipmentDTO;
using System.Collections.Generic;

namespace FitnessCenter.Data.Crud.EquipmentCRUD
{
    public abstract class EquipmentCrudFactoryBase
    {
        protected SqlDao dao;

        public abstract Dictionary<string, string> Create(EquipmentBaseClass entityDTO);
        public abstract Dictionary<string, string> Update(EquipmentBaseClass entityDTO);
        public abstract Dictionary<string, string> Delete(EquipmentBaseClass entityDTO);
        public abstract List<EquipmentBaseClass> RetrieveAll();
    }
}

