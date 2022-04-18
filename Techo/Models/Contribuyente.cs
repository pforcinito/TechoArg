using System;
using System.Collections.Generic;

#nullable disable

namespace Techo.Models
{
    public partial class Contribuyente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public short EntidadParticipativaId { get; set; }
        //public string NumeroDocumento { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }

        public virtual EntidadParticipativa EntidadParticipativa { get; set; }
    }
}
