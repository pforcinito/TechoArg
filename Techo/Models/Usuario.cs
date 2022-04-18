using System;
using System.Collections.Generic;

#nullable disable

namespace Techo.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
        }

        public short Id { get; set; }
        public string Nombre { get; set; }
        public string Password { get; set; }
        public bool Activo { get; set; }
        public bool Admin { get; set; }
    }
}
