using System;
using System.Collections.Generic;

namespace JMApi.Data
{
    public partial class Usuario
    {
        public Usuario()
        {
            Calificaciones = new HashSet<Calificacione>();
        }

        public int Id { get; set; }
        public string? NombreCompleto { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? CorreoElectronico { get; set; }
        public string? Rol { get; set; }
        public bool? Estado { get; set; }

        public virtual ICollection<Calificacione> Calificaciones { get; set; }
    }
}
