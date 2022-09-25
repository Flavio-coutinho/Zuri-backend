using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zuri.Dtos;
using Zuri.Models;
using Zuri.Services;

namespace Zuri.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;

        public LoginController (ILogger<LoginController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult EfetuarLogin([FromBody] LoginRequisicaoDto loginRequisition)
        {
            try
            {
                if(!String.IsNullOrEmpty(loginRequisition.Senha) && !String.IsNullOrEmpty(loginRequisition.Email) &&
                    !String.IsNullOrWhiteSpace(loginRequisition.Senha) && !String.IsNullOrWhiteSpace(loginRequisition.Email))
                {
                    string email = "coutinho@gmail.com";
                    string senha = "coutinho1996";

                    if(loginRequisition.Email == email && loginRequisition.Senha == senha)
                    {

                        Usuario usuario = new Usuario()
                        {
                            Email = loginRequisition.Email,
                            Id = 26,
                            Nome = "Flavio Coutinho"
                        };

                        return Ok(new LoginRespostaDto()
                        {
                            Email = usuario.Email,
                            Nome = usuario.Nome,
                            Token = TokenService.CriarToken(usuario)
                        });
                    }
                    else
                    {
                        return BadRequest(new ErrorRespostaDto()
                        {
                            Descricao = "Email ou senha inválida",
                            Status = StatusCodes.Status400BadRequest,

                        });
                    }
                }
                else
                {
                    return BadRequest(new ErrorRespostaDto()
                    {
                        Descricao = "Usuário não preencheu o campo de login correctamente",
                        Status = StatusCodes.Status400BadRequest,
                    });
                }
               
            }
            catch (Exception ex)
            {
                _logger.LogError("Ocorreu um erro no login " + ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorRespostaDto()
                {
                    Descricao = "Ocorreu um erro ao fazer o login",
                    Status = StatusCodes.Status500InternalServerError,
                });
            }
        }
    }
}
