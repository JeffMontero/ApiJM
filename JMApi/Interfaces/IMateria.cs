using JMApi.Data;
using JMApi.Model;

namespace JMApi.Interfaces
{
    public interface IMateria
    {
        public Task<List<Materium>> GetMaterias();
        public Task<Materium> GetMateria(int id);
        public Task<Materium> PostMateria(MateriaViewModel materia);
        public Task<Materium> PutMateria(MateriaViewModel materia);
        public Task<Materium> DeleteMateria(int id);
    }
}
