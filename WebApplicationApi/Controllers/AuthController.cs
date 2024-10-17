using Microsoft.AspNetCore.Mvc;
using WebApplicationApi.Services;

namespace WebApplicationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        [HttpPost]
        public IActionResult Auth(string username, string password)
        {
            Model.UserModel user = new Model.UserModel(1, "luciano", "123456");
            IActionResult actionResult = BadRequest("Usuário ou senha inválidos");
            if ( username == user.Nome && password == user.Senha )
            {
                var token = TokenServices.GenerateToken(user);
                actionResult = Ok(token);
            }
            return actionResult;
        }

    }
}
