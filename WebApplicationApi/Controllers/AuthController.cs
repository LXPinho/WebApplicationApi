using Microsoft.AspNetCore.Mvc;
using WebApplicationApi.Services;

namespace WebApplicationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        [HttpPost]
        public IActionResult Auth(string username = "luciano", string password= "123456")
        {
            Model.UserModel user = new Model.UserModel(1, username, password);
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
