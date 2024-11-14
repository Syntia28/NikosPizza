
using NikosPizza.Application.Repositories;
using NikosPizza.core.Entities;

namespace NikosPizza.Infraestructure.Repositories
{
    public class PizzaRepository : RepositoryBase<Pizza>, IPizzaRepository
    {
        public PizzaRepository(PizzaDbContext dbContext) : base(dbContext)
        {

        }
    }
}

