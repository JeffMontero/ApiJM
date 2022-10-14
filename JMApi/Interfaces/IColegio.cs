using JMApi.Data;
using JMApi.Model;

namespace JMApi.Interfaces
{
    public interface IColegio
    {
        public Task<List<Colegio>> GetColegios();
        public Task<Colegio> GetColegio(int id);
        public Task<Colegio> PostColegio(ColegioViewModel colegio);
        public Task<Colegio> PutColegio(ColegioViewModel colegio);
        public Task<Colegio> DeleteColegio(int id);

    }
}
