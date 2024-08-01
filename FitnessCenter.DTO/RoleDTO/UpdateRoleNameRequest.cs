using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenter.DTO.RoleDTO
{
    public class UpdateRoleNameRequest
    {
        public string OldRoleName { get; set; }
        public string NewRoleName { get; set; }
    }

}
