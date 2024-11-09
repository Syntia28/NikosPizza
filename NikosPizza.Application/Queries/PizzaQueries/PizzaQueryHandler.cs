using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikosPizza.Application.Queries.PizzaQueries
{
    public class PizzaQueryHandler : IRequestHandler<PizzaQuery, List<PizzaQueriesDTO>>
    {
        public PizzaQueryHandler() { }
        public Task<List<PizzaQueriesDTO>> Handle(PizzaQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
