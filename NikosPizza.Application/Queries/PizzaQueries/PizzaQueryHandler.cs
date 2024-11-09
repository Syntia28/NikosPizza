﻿using MediatR;
using NikosPizza.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                                             }).ToList();
            return respons;
        }

    }
}