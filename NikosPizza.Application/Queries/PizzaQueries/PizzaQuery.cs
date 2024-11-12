using MediatR;
using NikosPizza.core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikosPizza.Application.Queries.PizzaQueries
{
    public  class PizzaQuery: IRequest<List<PizzaQueriesDTO>>
    {
        public Guid TamanoPizzaId { get; set; }  // Agregar esta propiedad
    }
}

