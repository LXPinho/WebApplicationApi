using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplicationApi.Model;
using WebApplicationApi.Repository;

namespace WebApplicationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoSaidaController : Controller
    {
        //[Authorize]
        [HttpGet]
        public ActionResult<Pedidos4SaidaModel> GetSaida()
        {
            return new ListaReporitory().ListarSaida();
        }
    }
}
