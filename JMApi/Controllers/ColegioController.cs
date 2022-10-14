using JMApi.Interfaces;
using JMApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JMApi.Controllers
{
    [Route("api/colegios")]
    [ApiController]
    public class ColegioController : ControllerBase
    {
        private readonly IColegio _colegio;

        public ColegioController(IColegio colegio)
        {
            _colegio = colegio;
        }

        [HttpGet]
        public async Task<ActionResult<StatusViewModel>> GetColegios()
        {
            StatusViewModel status = new StatusViewModel();
            try
            {
                var colegios = await _colegio.GetColegios();

                status.IsSuccess = true;
                status.Message = "OK";
                status.ObjetoADeserializar = colegios;
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
        public async Task<ActionResult<StatusViewModel>> GetColegio(int id)
        {
            StatusViewModel status = new StatusViewModel();
            try
            {
                var colegio = await _colegio.GetColegio(id);

                status.IsSuccess = true;
                status.Message = "OK";
                status.ObjetoADeserializar = colegio;
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
        public async Task<ActionResult<StatusViewModel>> PostColegio([FromBody] ColegioViewModel colegio)
        {
            StatusViewModel status = new StatusViewModel();

            try
            {
                var datacolegio = await _colegio.PostColegio(colegio);

                status.IsSuccess = true;
                status.Message = "Insertado";
                status.ObjetoADeserializar = datacolegio;
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
        public async Task<ActionResult<StatusViewModel>> PutColegio([FromBody] ColegioViewModel colegio)
        {
            StatusViewModel status = new StatusViewModel();
            try
            {
                var datacolegio = await _colegio.PutColegio(colegio);

                status.IsSuccess = true;
                status.Message = "Actualizado";
                status.ObjetoADeserializar = datacolegio;
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
        public async Task<ActionResult<StatusViewModel>> DeleteColegio(int id)
        {
            StatusViewModel status = new StatusViewModel();
            try
            {
                var datacolegio = await _colegio.DeleteColegio(id);

                status.IsSuccess = true;
                status.Message = "Eliminado";
                status.ObjetoADeserializar = datacolegio;
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
