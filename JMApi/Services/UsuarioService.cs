using JMApi.Data;
using JMApi.Interfaces;
using JMApi.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace JMApi.Services
{
    public class UsuarioService : IUsuario
    {
        private ApplicationDbContext _ctx;

        public IConfiguration Configuration { get; }

        public UsuarioService(ApplicationDbContext ctx, IConfiguration configuration)
        {
            _ctx = ctx;
            this.Configuration = configuration;
        }

        public async Task<List<Usuario>> GetUsuarios()
        {
            try
            {
                var usuarios = await _ctx.Usuarios.ToListAsync();
                return usuarios;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception("ErrorConcurrencia");
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("ErrorIngresoDatos");
            }
            catch (SqlException ex)
            {
                throw new Exception("ErrorConexionBaseDatos");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Usuario> GetUsuario(int id)
        {
            try
            {
                var usuario = await _ctx.Usuarios.Where(x => x.Id == id).FirstOrDefaultAsync();
                return usuario;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception("ErrorConcurrencia");
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("ErrorIngresoDatos");
            }
            catch (SqlException ex)
            {
                throw new Exception("ErrorConexionBaseDatos");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Usuario> PostUsuario(UsuarioViewModel usuario)
        {
            try
            {
                Usuario _usuario = new Usuario();

                _usuario.NombreCompleto = usuario.Nombre;
                _usuario.Username = usuario.Nickname;
                _usuario.Password = usuario.Pass;
                _usuario.CorreoElectronico = usuario.Correo;
                _usuario.Rol = usuario.Rol;
                _usuario.Estado = true;

                _ctx.Usuarios.Add(_usuario);
                await _ctx.SaveChangesAsync();

                return _usuario;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception("ErrorConcurrencia");
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("ErrorIngresoDatos");
            }
            catch (SqlException ex)
            {
                throw new Exception("ErrorConexionBaseDatos");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Usuario> PutUsuario(UsuarioViewModel usuario)
        {
            try
            {
                var dataUsuario = await _ctx.Usuarios.Where(x => x.Id == usuario.Id).SingleOrDefaultAsync();

                
                dataUsuario.NombreCompleto = usuario.Nombre;
                dataUsuario.Username = usuario.Nickname;
                dataUsuario.Password = usuario.Pass;
                dataUsuario.CorreoElectronico = usuario.Correo;
                dataUsuario.Rol = usuario.Rol;
                
               
                await _ctx.SaveChangesAsync();

                return dataUsuario;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception("ErrorConcurrencia");
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("ErrorIngresoDatos");
            }
            catch (SqlException ex)
            {
                throw new Exception("ErrorConexionBaseDatos");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Usuario> DeleteUsuario(int id)
        {
            try
            {
                var dataUsuario = await _ctx.Usuarios.Where(x => x.Id == id).SingleOrDefaultAsync();

                dataUsuario.Estado = false;

                await _ctx.SaveChangesAsync();
                return dataUsuario;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception("ErrorConcurrencia");
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("ErrorIngresoDatos");
            }
            catch (SqlException ex)
            {
                throw new Exception("ErrorConexionBaseDatos");
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
