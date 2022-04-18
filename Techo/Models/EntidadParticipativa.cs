using System;
using System.Collections.Generic;

#nullable disable

namespace Techo.Models
{
    public partial class EntidadParticipativa
    {
        public EntidadParticipativa()
        {
            Contribuyentes = new HashSet<Contribuyente>();
        }

        public short Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Contribuyente> Contribuyentes { get; set; }
    }
}
