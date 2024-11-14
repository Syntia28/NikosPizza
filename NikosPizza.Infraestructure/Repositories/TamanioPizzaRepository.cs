
using NikosPizza.Application.Repositories;
using NikosPizza.core.Entities;

namespace NikosPizza.Infraestructure.Repositories
{
    public class TamanioPizzaRepository : RepositoryBase<TamanioPizza>, ITamanioPizzaRepository
    {
        public TamanioPizzaRepository(PizzaDbContext dbContext) : base(dbContext)
        { }
    }
}