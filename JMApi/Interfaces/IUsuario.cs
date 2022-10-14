using JMApi.Data;
using JMApi.Model;

namespace JMApi.Interfaces
{
    public interface IUsuario
    {
        public Task<List<Usuario>> GetUsuarios();
        public Task<Usuario> GetUsuario(int id);
        public Task<Usuario> PostUsuario(UsuarioViewModel usuario);
        public Task<Usuario> PutUsuario(UsuarioViewModel usuario);
        public Task<Usuario> DeleteUsuario(int id);
    }
}
