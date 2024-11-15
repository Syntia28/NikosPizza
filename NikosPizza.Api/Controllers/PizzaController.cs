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

        public async Task<ActionResult> ListarPizzas([FromQuery] string codigo)
        {
            var pizzaQuery = new PizzaQuery
            {
                CodigoTamanioPizza = codigo
            };
            
            var result = await _mediator.Send(pizzaQuery);

            return View(result);
        }

    }
}
