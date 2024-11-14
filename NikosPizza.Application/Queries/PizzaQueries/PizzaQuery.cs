using MediatR;

namespace NikosPizza.Application.Queries.PizzaQueries
{
    public  class PizzaQuery: IRequest<List<PizzaQueriesDTO>>
    {
        public string CodigoTamanioPizza { get; set; } 
    }
}

