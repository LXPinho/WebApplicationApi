using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using WebApplicationApi.Model;
using WebApplicationApi.Repository;

namespace WebApplicationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoEntradaController : Controller
    {
        //[Authorize]
        [HttpGet("Listar/{id}")]
        public ActionResult<Pedidos4EntradaModel> Get( int id = 0) 
        {
            return new ListaReporitory().ListarEntrada(id);
        }

        //[Authorize]
        [HttpPost("Importar")]
        public ActionResult<Pedidos4EntradaModel> Importar()
        {
            return new ListaReporitory().Importar();
        }
#if false
        [HttpPost("Adicionar/{pedido}")]
        [Authorize]
        public String? Post(PedidoEntradaModel pedido)
        {
            return new ListaReporitory().Adicionar(pedido);
        }
        [HttpPut]
        [Authorize]
        public String? PutPedidoEntrada()
        {
            return null;// new BaseDao(new ParametroDao()).Listar(new ParametroModel());
        }
        [HttpDelete]
        [Authorize]
        public String? DeletePedidoEntrada()
        {
            return null;// new BaseDao(new ParametroDao()).Listar(new ParametroModel());
        }
#endif
    }
}
