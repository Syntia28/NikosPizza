using System.Linq.Expressions;
using MediatR;
using NikosPizza.Application.Repositories;
using NikosPizza.core.Entities;

namespace NikosPizza.Application.Queries.PizzaQueries
{
    public class PizzaQueryHandler : IRequestHandler<PizzaQuery, List<PizzaQueriesDTO>>
    {
        private readonly IPizzaRepository _pizzaRepository;
        private readonly ITamanioPizzaRepository _tamanioPizzaRepository;
        public PizzaQueryHandler(IPizzaRepository pizzaRepository, ITamanioPizzaRepository tamanioPizzaRepository)
        {
            _pizzaRepository = pizzaRepository;
            _tamanioPizzaRepository = tamanioPizzaRepository;

        }
        public async Task<List<PizzaQueriesDTO>> Handle(PizzaQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<TamanioPizza, bool>> fAllTamanioPizza = x => x.Codigo == request.CodigoTamanioPizza;

            var TamanioPizza = await _tamanioPizzaRepository.GetAsync(fAllTamanioPizza);


            var dataPizza = await _pizzaRepository.GetAllAsync();

            List<PizzaQueriesDTO> respons = (from x in dataPizza.Where(x => x.TamanioPizzaId == TamanioPizza.FirstOrDefault().TamanioPizzaId)
                                            
                                             select new PizzaQueriesDTO
                                             {
                                                 Id = x.PizzaId,
                                                 Nombre = x.Nombre,
                                                 Precio = x.Precio.ToString(),
                                                 Descripcion = x.Descripcion,
                                                 Url = x.ImagenUrl,
                                                 TamanoPizzaId = x.TamanioPizzaId,
                                             }).ToList();
            return respons.ToList();
        }

    }
}
