using JMApi.Interfaces;
using JMApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JMApi.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuario _usuario;

        public UsuarioController(IUsuario usuario)
        {
            _usuario = usuario;
        }

        [HttpGet]
        public async Task<ActionResult<StatusViewModel>> GetUsuarios()
        {
            StatusViewModel status = new StatusViewModel();
            try
            {
                var usuarios = await _usuario.GetUsuarios();

                status.IsSuccess = true;
                status.Message = "OK";
                status.ObjetoADeserializar = usuarios;
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
        public async Task<ActionResult<StatusViewModel>> GetUsuario(int id)
        {
            StatusViewModel status = new StatusViewModel();
            try
            {
                var usuario = await _usuario.GetUsuario(id);

                status.IsSuccess = true;
                status.Message = "OK";
                status.ObjetoADeserializar = usuario;
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
        public async Task<ActionResult<StatusViewModel>> PostUsuario([FromBody] UsuarioViewModel usuario)
        {
            StatusViewModel status = new StatusViewModel();

            try
            {
                var dataUsuario = await _usuario.PostUsuario(usuario);

                status.IsSuccess = true;
                status.Message = "Insertado";
                status.ObjetoADeserializar = dataUsuario;
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
        public async Task<ActionResult<StatusViewModel>> PutUsuario([FromBody] UsuarioViewModel usuario)
        {
            StatusViewModel status = new StatusViewModel();
            try
            {
                var dataUsuario = await _usuario.PutUsuario(usuario);

                status.IsSuccess = true;
                status.Message = "Actualizado";
                status.ObjetoADeserializar = dataUsuario;
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
        public async Task<ActionResult<StatusViewModel>> DeleteUsuario(int id)
        {
            StatusViewModel status = new StatusViewModel();
            try
            {
                var dataUsuario = await _usuario.DeleteUsuario(id);

                status.IsSuccess = true;
                status.Message = "Eliminado";
                status.ObjetoADeserializar = dataUsuario;
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
