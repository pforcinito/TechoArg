using Techo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Techo.ViewModels
{
    public class ContribuyenteModalViewModel : ContribuyenteViewModel
    {
        public ContribuyenteModalViewModel()
        {
            EntidadParticipativa = new List<EntidadParticipativa>();
        }

        [Display(Name = "Entidad Participativa")]
        [Required(ErrorMessage = "Seleccione entidad participativa")]
        public virtual List<EntidadParticipativa> EntidadParticipativa { get; set; }
    }
}

