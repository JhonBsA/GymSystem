using System.ComponentModel.DataAnnotations;

namespace FitnessCenter.Web.Models.Role
{
    public class UpdateRoleAccessViewModel
    {
        public int RoleId { get; set; }
        [Required]
        [Display(Name = "Nombre del Rol")]
        public string RoleName { get; set; }
        [Display(Name = "Permisos (BETA)")]
        public int RoleAccess { get; set; }
    }
}
