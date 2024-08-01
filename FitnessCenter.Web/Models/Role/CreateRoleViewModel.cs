using System.ComponentModel.DataAnnotations;
using System.IO;

namespace FitnessCenter.Web.Models.Role
{
    public class CreateRoleViewModel
    {
        [Required]
        [Display(Name = "Nombre del Rol")]
        public string RoleName { get; set; }

        [Required]
        [Display(Name = "Permisos (BETA)")]

        public List<Access> RoleAccess { get; set; }

        public List<int> SelectedAccessIds { get; set; }
    }

    public class Access
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
