using JMApi.Data;
using JMApi.Interfaces;
using JMApi.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace JMApi.Services
{
    public class ColegioService : IColegio
    {
        private ApplicationDbContext _ctx;

        public IConfiguration Configuration { get;}

        public ColegioService(ApplicationDbContext ctx, IConfiguration configuration)
        {
            _ctx = ctx;
            this.Configuration = configuration;
        }

        public async Task<List<Colegio>> GetColegios()
        {
            try
            {
                var colegios = await _ctx.Colegios.ToListAsync();
                return colegios;
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

        public async Task<Colegio> GetColegio(int id)
        {
            try
            {
                var colegio = await _ctx.Colegios.Where(x=> x.Id == id).FirstOrDefaultAsync();
                return colegio;
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

        public async Task<Colegio> PostColegio(ColegioViewModel colegio)
        {
            try
            {
                Colegio _colegio = new Colegio();
                
                _colegio.Nombre = colegio.Nombre;
                _colegio.TipoColegio = colegio.TipoColegio;
                _colegio.Estado = true;

                _ctx.Colegios.Add(_colegio);
                await _ctx.SaveChangesAsync();

                return _colegio;
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

        public async Task<Colegio> PutColegio(ColegioViewModel colegio)
        {
            try
            {
                var dataColegio = await _ctx.Colegios.Where(x => x.Id == colegio.Id).SingleOrDefaultAsync();

                dataColegio.Nombre = colegio.Nombre;
                dataColegio.TipoColegio = colegio.TipoColegio;

                await _ctx.SaveChangesAsync();
                return dataColegio;
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

        public async Task<Colegio> DeleteColegio(int id)
        {
            try
            {
                var dataColegio = await _ctx.Colegios.Where(x => x.Id == id).SingleOrDefaultAsync();

                dataColegio.Estado = false;

                await _ctx.SaveChangesAsync();
                return dataColegio;
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
