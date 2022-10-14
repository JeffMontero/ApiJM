using JMApi.Data;
using JMApi.Model;

namespace JMApi.Interfaces
{
    public interface ICalificacion
    {
        public Task<List<Calificacione>> GetCalificaciones();
        public Task<Calificacione> GetCalificacion(int id);
        public Task<Calificacione> PostCalificacion(CalificacionViewModel calificacion);
        public Task<Calificacione> PutCalificacion(CalificacionViewModel calificacion);
        public Task<Calificacione> DeleteCalificacion(int id);
    }
}
