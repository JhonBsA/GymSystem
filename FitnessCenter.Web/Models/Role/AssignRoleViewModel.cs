using System.ComponentModel.DataAnnotations;

namespace FitnessCenter.Web.Models.User
{
    public class AssignRoleViewModel
    {
        

        [Display(Name = "ID de Usuario")]
        public int UserID { get; set; }

        [Display(Name = "Cedula")]
        public string? Cedula { get; set; }


        [Display(Name = "Nombre")]
        public string? Nombre { get; set; }

        [Display(Name = "Primer Apellido")]
        public string? FirstLastName { get; set; }

        [Display(Name = "Segundo Apellido")]
        public string? SecondLastName { get; set; }

        [Display(Name = "Teléfono")]
        public string? Phone { get; set; }

        [Display(Name = "Correo Electrónico")]
        public string? Email { get; set; }

        [Display(Name = "Rol")]
        public string? RoleName { get; set; }


        // Puedes agregar un campo adicional para determinar si se asignará un rol
        public bool IsAssigned { get; set; }
    }
}
