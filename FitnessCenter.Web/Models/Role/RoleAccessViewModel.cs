using System.ComponentModel.DataAnnotations;

namespace FitnessCenter.Web.Models.Role
{
    public class RoleAccessViewModel
    {
        public int AccessId { get; set; }

        [Display(Name = "Acceso")]
        public string AccessName { get; set; }

        [Display(Name = "Descripción")]
        public string Description { get; set; }

        [Display(Name = "Roles con el Acceso")]
        public List<string> RolesWithAccess { get; set; }
    }
}
