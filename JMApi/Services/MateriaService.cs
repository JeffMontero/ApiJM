using JMApi.Data;
using JMApi.Interfaces;
using JMApi.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace JMApi.Services
{
    public class MateriaService : IMateria
    {
        private ApplicationDbContext _ctx;

        public IConfiguration Configuration { get; }

        public MateriaService(ApplicationDbContext ctx, IConfiguration configuration)
        {
            _ctx = ctx;
            this.Configuration = configuration;
        }

        public async Task<List<Materium>> GetMaterias()
        {
            try
            {
                var materias = await _ctx.Materia.ToListAsync();
                return materias;
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

        public async Task<Materium> GetMateria(int id)
        {
            try
            {
                var materia = await _ctx.Materia.Where(x=> x.Id == id).FirstOrDefaultAsync();
                return materia;
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

        public async Task<Materium> PostMateria(MateriaViewModel materia)
        {
            try
            {
                Materium _materia = new Materium();

                _materia.IdColegio = materia.IdColegio;
                _materia.Nombre = materia.Nombre;
                _materia.Area = materia.Area;
                _materia.NumeroEstudiantes = materia.NumEstudiantes;
                _materia.DocenteAsignado = materia.docenteAsignado;
                _materia.Curso = materia.Curso;
                _materia.Paralelo = materia.Paralelo;
                _materia.Estado = true;

                _ctx.Materia.Add(_materia);

                await _ctx.SaveChangesAsync();

                return _materia;
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

        public async Task<Materium> PutMateria(MateriaViewModel materia)
        {
            try
            {
                var dataMateria = await _ctx.Materia.Where(x=> x.Id == materia.Id).SingleOrDefaultAsync();

                dataMateria.IdColegio = materia.IdColegio;
                dataMateria.Nombre = materia.Nombre;
                dataMateria.Area = materia.Area;
                dataMateria.NumeroEstudiantes = materia.NumEstudiantes;
                dataMateria.DocenteAsignado = materia.docenteAsignado;
                dataMateria.Curso = materia.Curso;
                dataMateria.Paralelo = materia.Paralelo;
                dataMateria.Estado = true;

                

                await _ctx.SaveChangesAsync();

                return dataMateria;
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

        public async Task<Materium> DeleteMateria(int id)
        {
            try
            {
                var dataMateria = await _ctx.Materia.Where(x => x.Id == id).SingleOrDefaultAsync();

                dataMateria.Estado = false;

                await _ctx.SaveChangesAsync();
                return dataMateria;
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
