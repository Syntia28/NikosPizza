using MediatR;
using NikosPizza.Application.Repositories;

namespace NikosPizza.Application.Queries.PizzaQueries
{
    public class PizzaQueryHandler : IRequestHandler<PizzaQuery, List<PizzaQueriesDTO>>
    {
        private readonly IPizzaRepository _pizzaRepository;
        public PizzaQueryHandler(IPizzaRepository pizzaRepository) 
        {
            _pizzaRepository = pizzaRepository;
        }
        public async Task<List<PizzaQueriesDTO>> Handle(PizzaQuery request, CancellationToken cancellationToken)
        {
          var dataPizza = await _pizzaRepository.GetAllAsync();
         
            List<PizzaQueriesDTO> respons = (from x in dataPizza
                                             select new PizzaQueriesDTO
                                             {
                                                 Id = x.PizzaId,
                                                 Nombre = x.Nombre,
                                                 Precio = x.Precio.ToString(),
                                                 Descripcion = x.Descripcion,
                                                 Url=x.ImagenUrl,
                                                 TamanoPizzaId = x.TamanioPizzaId,
                                             }).ToList();
            return respons.Where(x => x.TamanoPizzaId == request.TamanoPizzaId).ToList();
        }

    }
}
