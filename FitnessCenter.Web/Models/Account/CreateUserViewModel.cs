using System.ComponentModel.DataAnnotations;

namespace FitnessCenter.Web.Models.Account
{
    public class CreateUserViewModel
    {
        [Required(ErrorMessage = "La identificación es requerida.")]
        [Display(Name = "Identificación")]
        public int Identificacion { get; set; }

        [Required(ErrorMessage = "El nombre es requerido.")]
        [Display(Name = "Nombre")]
        [StringLength(50, ErrorMessage = "El nombre no puede exceder los 50 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El primer apellido es requerido.")]
        [Display(Name = "Primer Apellido")]
        [StringLength(50, ErrorMessage = "El primer apellido no puede exceder los 50 caracteres.")]
        public string PrimerApellido { get; set; }

        [Required(ErrorMessage = "El segundo apellido es requerido.")]
        [Display(Name = "Segundo Apellido")]
        [StringLength(50, ErrorMessage = "El segundo apellido no puede exceder los 50 caracteres.")]
        public string SegundoApellido { get; set; }

        [Required(ErrorMessage = "El teléfono es requerido.")]
        [Display(Name = "Teléfono")]
        [StringLength(50, ErrorMessage = "El teléfono no puede exceder los 50 caracteres.")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El correo electrónico es requerido.")]
        [Display(Name = "Correo Electrónico")]
        [EmailAddress(ErrorMessage = "El correo electrónico no es válido.")]
        [StringLength(100, ErrorMessage = "El correo electrónico no puede exceder los 100 caracteres.")]
        public string CorreoElectronico { get; set; }
    }
}
