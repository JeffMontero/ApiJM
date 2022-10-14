using JMApi.Interfaces;
using JMApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JMApi.Controllers
{
    [Route("api/materia")]
    [ApiController]
    public class MateriaController : ControllerBase
    {
        private readonly IMateria _materia;

        public MateriaController(IMateria materia)
        {
            _materia = materia;
        }

        [HttpGet]
        public async Task<ActionResult<StatusViewModel>> GetMaterias()
        {
            StatusViewModel status = new StatusViewModel();
            try
            {
                var materias = await _materia.GetMaterias();

                status.IsSuccess = true;
                status.Message = "OK";
                status.ObjetoADeserializar = materias;
                return status;
            }
            catch (Exception ex)
            {
                status.IsSuccess = false;
                status.Message = ex.Message;
                return status;
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StatusViewModel>> GetMateria(int id)
        {
            StatusViewModel status = new StatusViewModel();
            try
            {
                var materia = await _materia.GetMateria(id);

                status.IsSuccess = true;
                status.Message = "OK";
                status.ObjetoADeserializar = materia;
                return status;
            }
            catch (Exception ex)
            {
                status.IsSuccess = false;
                status.Message = ex.Message;
                return status;
            }
        }

        [HttpPost]
        public async Task<ActionResult<StatusViewModel>> PostMateria([FromBody] MateriaViewModel materia)
        {
            StatusViewModel status = new StatusViewModel();

            try
            {
                var dataMateria = await _materia.PostMateria(materia);

                status.IsSuccess = true;
                status.Message = "Insertado";
                status.ObjetoADeserializar = dataMateria;
                return status;
            }
            catch (Exception ex)
            {
                status.IsSuccess = false;
                status.Message = ex.Message;
                return status;
            }
        }

        [HttpPut]
        public async Task<ActionResult<StatusViewModel>> PutMateria([FromBody] MateriaViewModel materia)
        {
            StatusViewModel status = new StatusViewModel();
            try
            {
                var dataMateria = await _materia.PutMateria(materia);

                status.IsSuccess = true;
                status.Message = "Actualizado";
                status.ObjetoADeserializar = dataMateria;
                return status;
            }
            catch (Exception ex)
            {
                status.IsSuccess = false;
                status.Message = ex.Message;
                return status;
            }
        }

        [HttpDelete]
        public async Task<ActionResult<StatusViewModel>> DeleteMateria(int id)
        {
            StatusViewModel status = new StatusViewModel();
            try
            {
                var dataMateria = await _materia.DeleteMateria(id);

                status.IsSuccess = true;
                status.Message = "Eliminado";
                status.ObjetoADeserializar = dataMateria;
                return status;
            }
            catch (Exception ex)
            {
                status.IsSuccess = false;
                status.Message = ex.Message;
                return status;
            }
        }
    }
}
