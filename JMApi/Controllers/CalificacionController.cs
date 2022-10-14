using JMApi.Interfaces;
using JMApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JMApi.Controllers
{
    [Route("api/calificacion")]
    [ApiController]
    public class CalificacionController : ControllerBase
    {
        private readonly ICalificacion _calificacion;

        public CalificacionController(ICalificacion calificacion)
        {
            _calificacion = calificacion;
        }

        [HttpGet]
        public async Task<ActionResult<StatusViewModel>> GetCalificaciones()
        {
            StatusViewModel status = new StatusViewModel();
            try
            {
                var calificaciones = await _calificacion.GetCalificaciones();

                status.IsSuccess = true;
                status.Message = "OK";
                status.ObjetoADeserializar = calificaciones;
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
        public async Task<ActionResult<StatusViewModel>> GetCalificacion(int id)
        {
            StatusViewModel status = new StatusViewModel();
            try
            {
                var calificacion = await _calificacion.GetCalificacion(id);

                status.IsSuccess = true;
                status.Message = "OK";
                status.ObjetoADeserializar = calificacion;
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
        public async Task<ActionResult<StatusViewModel>> PostCalificacion([FromBody] CalificacionViewModel calificacion)
        {
            StatusViewModel status = new StatusViewModel();

            try
            {
                var dataCalificacion = await _calificacion.PostCalificacion(calificacion);

                status.IsSuccess = true;
                status.Message = "Insertado";
                status.ObjetoADeserializar = dataCalificacion;
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
        public async Task<ActionResult<StatusViewModel>> PutCalificacion([FromBody] CalificacionViewModel calificacion)
        {
            StatusViewModel status = new StatusViewModel();
            try
            {
                var dataCalificacion = await _calificacion.PutCalificacion(calificacion);

                status.IsSuccess = true;
                status.Message = "Actualizado";
                status.ObjetoADeserializar = dataCalificacion;
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
        public async Task<ActionResult<StatusViewModel>> DeleteCalificacion(int id)
        {
            StatusViewModel status = new StatusViewModel();
            try
            {
                var dataCalificaion = await _calificacion.DeleteCalificacion(id);

                status.IsSuccess = true;
                status.Message = "Eliminado";
                status.ObjetoADeserializar = dataCalificaion;
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
