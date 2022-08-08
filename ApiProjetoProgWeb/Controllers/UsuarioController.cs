using ApiProjetoProgWeb.Model;
using ApiProjetoProgWeb.Model.DTO;
using ApiProjetoProgWeb.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjetoProgWeb.Controllers
{
    [ApiController]
    [Route("usuario")]
    public class UsuarioController : ControllerBase
    {
        private SignInManager<Usuario> _signinManager;
        private UserManager<Usuario> _userManager;

        public UsuarioController(SignInManager<Usuario> signin, UserManager<Usuario> userManager)
        {
            _signinManager = signin;
            _userManager = userManager;
        }

        [HttpPost("cadastrar", Name = "Cadastro")]
        public async Task<IActionResult> CadastrarUsuarioAsync(UsuarioDTO usuarioDTO)
        {
            var usuario = new Usuario
            {
                UserName = usuarioDTO.usuario
            };
            
            var resultado = await _userManager.CreateAsync(usuario, usuarioDTO.senha);
            if (resultado.Succeeded)
            {
                return Ok("Usuário cadastrado com sucesso");
            }
            else
            {
                var erros = string.Join("\n", resultado.Errors.Select(x => x.Description).ToList());
                return Problem(title: "Ocorreu um erro ao cadastrar o usuário", detail: erros);
            }
        }

        [HttpPost("login", Name = "Login")]
        public async Task<IActionResult> LoginAsync(UsuarioDTO usuarioDTO)
        {
            var usuario = new Usuario
            {
                UserName = usuarioDTO.usuario
            };

            var resultado = await _signinManager.PasswordSignInAsync(usuario.UserName, usuarioDTO.senha, false, false);
            if (resultado.Succeeded)
            {
                return Ok(TokenService.GenerateToken(usuario));
            }
            else
            {
                return Unauthorized("Usuário ou senha estão incorretos");
            }
        }

        [HttpGet("teste", Name = "Teste")]
        [Authorize]
        public IActionResult TesteToken()
        {
            return Ok("Token válido!");
        }
    }
}
