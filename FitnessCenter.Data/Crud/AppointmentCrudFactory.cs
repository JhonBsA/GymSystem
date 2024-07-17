using FitnessCenter.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenter.Data.Crud
{
    public class AppointmentCrudFactory : CrudFactory
    {
        public override Dictionary<string, string> Create(BaseClass users)
        {
            throw new NotImplementedException();
        }
        public override Dictionary<string, string> Delete(BaseClass entityDTO)
        {
            throw new NotImplementedException();
        }
        public override List<T> RetrieveAll<T>()
        {
            throw new NotImplementedException();
        }
        public override BaseClass RetrieveById(int id)
        {
            throw new NotImplementedException();
        }
        public override Dictionary<string, string> Update(BaseClass entityDTO)
        {
            throw new NotImplementedException();
        }
    }
}
