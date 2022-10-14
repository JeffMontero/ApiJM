using System;
using System.Collections.Generic;

namespace JMApi.Data
{
    public partial class Colegio
    {
        public Colegio()
        {
            Calificaciones = new HashSet<Calificacione>();
            Materia = new HashSet<Materium>();
        }

        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? TipoColegio { get; set; }
        public bool? Estado { get; set; }

        public virtual ICollection<Calificacione> Calificaciones { get; set; }
        public virtual ICollection<Materium> Materia { get; set; }
    }
}
