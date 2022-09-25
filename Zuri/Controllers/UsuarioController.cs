using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Zuri.Dtos;
using Zuri.Models;

namespace Zuri.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : BaseController
    {
        public readonly ILogger<UsuarioController> _logger;

        public UsuarioController(ILogger<UsuarioController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult ObterUsuario()
        {

            try
            {
                Usuario usuario = new Usuario()
                {
                    Email = "coutinho@gmail.com",
                    Nome = "Flavio Coutinho",
                    Id = 21
                };

                return Ok(usuario);
            }
            catch (Exception e)
            {
                _logger.LogError("Ocorreu um erro ao obter o usuário");
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorRespostaDto()
                {
                    Descricao = "Ocorreu o seguinte erro: " + e.Message,
                    Status = StatusCodes.Status500InternalServerError
                });
            }

        }
    }

  

    
}
