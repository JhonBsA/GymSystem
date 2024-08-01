using System.ComponentModel.DataAnnotations;

namespace FitnessCenter.Web.Models.Role
{
    public class ListRolesViewModel
    {
        public int RoleID { get; set; }

        [Display(Name = "Nombre del Rol")]
        public string Name { get; set; }
    }
}
