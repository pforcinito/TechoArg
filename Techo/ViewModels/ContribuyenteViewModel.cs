using Techo.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Techo.ViewModels
{
    public class ContribuyenteViewModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Ingrese nombre")]
        [DataType(DataType.Text, ErrorMessage = "Por favor ingrese solo texto")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [DataType(DataType.Text, ErrorMessage = "Por favor ingrese solo texto")]
        [Display(Name = "Apellido")]
        public string Apellido { get; set; }

        [Display(Name = "Entidad Participativa")]
        public virtual EntidadParticipativaViewModel EntidadParticipativa { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "Debe seleccionar una entidad")]
        public short EntidadParticipativaId { get; set; }

        //[Display(Name = "Numero Documento")]
        //public string NumeroDocumento { get; set; }
        
        [Display(Name = "Telefono")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Por favor ingrese solo valores numericos")]
        public string Telefono { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Por favor ingrese solo texto")]
        public string Email { get; set; }
    }
}