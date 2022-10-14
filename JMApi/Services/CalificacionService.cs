using JMApi.Data;
using JMApi.Interfaces;
using JMApi.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace JMApi.Services
{
    public class CalificacionService : ICalificacion 
    {
        private ApplicationDbContext _ctx;

        public IConfiguration Configuration { get; }

        public CalificacionService(ApplicationDbContext ctx, IConfiguration configuration)
        {
            _ctx = ctx;
            this.Configuration = configuration;
        }

        public async Task<List<Calificacione>> GetCalificaciones()
        {
            try
            {
                var calificaciones = await _ctx.Calificaciones.ToListAsync();
                return calificaciones;
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

        public async Task<Calificacione> GetCalificacion(int id)
        {
            try
            {
                var calificacion = await _ctx.Calificaciones.Where(x => x.Id == id).FirstOrDefaultAsync();
                return calificacion;
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

        public async Task<Calificacione> PostCalificacion(CalificacionViewModel calificacion)
        {
            try
            {
                Calificacione _calificacion = new Calificacione();

                _calificacion.IdColegio = calificacion.IdColegio;
                _calificacion.IdMateria = calificacion.IdMateria;
                _calificacion.IdUsuario = calificacion.IdUsuario;
                _calificacion.Calificacion = calificacion.Calificacion;
                _calificacion.Estado = true;

                _ctx.Calificaciones.Add(_calificacion);

                await _ctx.SaveChangesAsync();
                return _calificacion;
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

        public async Task<Calificacione> PutCalificacion(CalificacionViewModel calificacion)
        {
            try
            {
                var dataCalificacion = await _ctx.Calificaciones.Where(x => x.Id == calificacion.Id).SingleOrDefaultAsync();

                dataCalificacion.IdColegio = calificacion.IdColegio;
                dataCalificacion.IdMateria = calificacion.IdMateria;
                dataCalificacion.IdUsuario = calificacion.IdUsuario;
                dataCalificacion.Calificacion = calificacion.Calificacion;
                

                await _ctx.SaveChangesAsync();
                return dataCalificacion;
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

        public async Task<Calificacione> DeleteCalificacion(int id)
        {
            try
            {
                var dataCalificacion = await _ctx.Calificaciones.Where(x => x.Id == id).SingleOrDefaultAsync();

                dataCalificacion.Estado = false;

                await _ctx.SaveChangesAsync();
                return dataCalificacion;
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
