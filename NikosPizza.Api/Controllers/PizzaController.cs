using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NikosPizza.Application.Queries.PizzaQueries;

namespace NikosPizza.Api.Controllers
{
    [Route("Pizzas")]
    public class PizzaController : Controller
    {
        private readonly IMediator _mediator;
        public PizzaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("ListarPizzas")]
        [ProducesResponseType(typeof(List<PizzaQueriesDTO>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> ListarPizzas()
        {
            var pizzaQuery = new PizzaQuery();
            var result = await _mediator.Send(pizzaQuery);

            return View(result);
        }
        [HttpGet("FiltrarPizzasPorTamano")]
        public async Task<IActionResult> FiltrarPizzasPorTamano()
        {
            // Genera un `Guid` dinámico para `TamanoPizzaId`
            var tamanoPizzaId = Guid.NewGuid();

            // Crea la consulta `PizzaQuery` con el `TamanoPizzaId` generado
            var pizzaQuery = new PizzaQuery
            {
                TamanoPizzaId = tamanoPizzaId
            };

            // Envía la consulta a través de Mediator
            var result = await _mediator.Send(pizzaQuery);

            // Retorna los resultados
            return Ok(result);
        }
    }
}
