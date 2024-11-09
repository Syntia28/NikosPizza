using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NikosPizza.Application.Queries.PizzaQueries;

namespace NikosPizza.Api.Controllers
{
    [Route("api/v1/[controller]")]
    public class PizzaController : Controller
    {
        private readonly IMediator _mediator;
        public PizzaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("ListarPizzas")]
        [ProducesResponseType(typeof(List<PizzaQueriesDTO>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<PizzaQueriesDTO>>> Crear()
        {
            PizzaQuery pizzaQuery = new PizzaQuery();
            var result = await _mediator.Send(pizzaQuery);
            return Ok(result);
        }
    }
}
