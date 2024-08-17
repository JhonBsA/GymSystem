using System.ComponentModel.DataAnnotations;

namespace FitnessCenter.Web.Models.Role
{
    public class AssignRoleViewModel
    {
        public int UserID { get; set; }
        public string RoleName { get; set; }
    }
}
