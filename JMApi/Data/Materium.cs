using System;
using System.Collections.Generic;

namespace JMApi.Data
{
    public partial class Materium
    {
        public Materium()
        {
            Calificaciones = new HashSet<Calificacione>();
        }

        public int Id { get; set; }
        public int? IdColegio { get; set; }
        public string? Nombre { get; set; }
        public string? Area { get; set; }
        public int? NumeroEstudiantes { get; set; }
        public string? DocenteAsignado { get; set; }
        public string? Curso { get; set; }
        public string? Paralelo { get; set; }
        public bool? Estado { get; set; }

        public virtual Colegio? IdColegioNavigation { get; set; }
        public virtual ICollection<Calificacione> Calificaciones { get; set; }
    }
}
