using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Swashbuckle.AspNetCore.Examples;
using System.Net;
using System.Threading.Tasks;
using Livraria.Api.ObjectModel;

namespace Livraria.Api.Controllers.v1.prv
{
    [Route("v1/private/[controller]")]
    public partial class PagamentoController : Controller
    {
        /// <summary>
        /// Se o valor for 5510 4481 5196 2381 o valor será true, caso contrário, false
        /// </summary>
        /// <param name="dadosPagamento">Dados pagamento enviado no corpo da página</param>
        /// <response code="200">True</response>
        /// <response code="400">False</response>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DadosPagamento dadosPagamento)
        {
            if(dadosPagamento != null)
            {
                if (dadosPagamento.NumeroCartao == "5510 4481 5196 2381")
                {
                    return Ok(true);
                }
            }

            return Ok(false);
        }
    }
}
