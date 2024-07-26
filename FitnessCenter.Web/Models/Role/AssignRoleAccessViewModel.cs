using System.ComponentModel.DataAnnotations;

namespace FitnessCenter.Web.Models.Role
{
    public class AssignRoleAccessViewModel
    {
        [Display(Name = "IdRol")]
        public int RoleId { get; set; }
        [Display(Name = "Nombre del Rol")]
        public string RoleName { get; set; }
        [Display(Name = "Descripción")]
        public string Description { get; set; }
        public bool HasAccess { get; set; } // Para determinar si el acceso está asignado
    }
}
