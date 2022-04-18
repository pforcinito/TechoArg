using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Techo.ViewModels
{
    public class EntidadParticipativaViewModel
    {
        public short Id { get; set; }

        [Display(Name = "Tipo de Documento")]
        public string Nombre { get; set; }

        //public virtual ICollection<Cliente> Clientes { get; set; }
    }
}
