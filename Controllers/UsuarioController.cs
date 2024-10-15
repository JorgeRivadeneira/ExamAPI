using ExamAPI.Contracts;
using ExamAPI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ExamAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuario _usuario;

        public UsuarioController(IUsuario usuario)
        {
            _usuario = usuario;
        }

        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> Get()
        {
            try
            {
                var usuarios = await _usuario.GetUsersAsync();
                if(usuarios.Count == 0)
                {
                    NotFound("Usuario no encontrado en la bdd");
                }
                return Ok(usuarios);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{userId:int}/usuarioById")]
        public async Task<ActionResult<Usuario>> GetById(int usuarioId)
        {
            try
            {
                var usuario = await _usuario.GetUserById(usuarioId);
                if(usuario is null)
                {
                    return NotFound("Usuario no encontrado");
                }

                return Ok(usuario);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<bool>> Create([FromBody] Usuario usuario)
        {
            try
            {
                var result = await _usuario.CreateUserAsync(usuario);
                if (!result)
                {
                    return StatusCode(500, "Internal Server Error");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<bool>> Update([FromBody] Usuario usuario)
        {
            try
            {
                var result = await _usuario.UpdateUserAsync(usuario);
                if (!result)
                {
                    return StatusCode(500, "Internal Server Error");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{usuarioId:int}")]
        public async Task<ActionResult<bool>> Delete(int usuarioId)
        {
            try
            {
                var result = await _usuario.DeleteUserAsync(usuarioId);
                if (!result)
                {
                    return StatusCode(500, "Internal Server Error");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
