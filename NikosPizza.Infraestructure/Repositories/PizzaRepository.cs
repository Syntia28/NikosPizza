using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NikosPizza.Application;
using NikosPizza.Application.Repositories;
using NikosPizza.core.Entities;

namespace NikosPizza.Infraestructure.Repositories
{
    public class PizzaRepository :  RepositoryBase<Pizza>, IPizzaRepository
    {
        public PizzaRepository(PizzaDbContext dbContext) : base(dbContext)
        {

        }
    }
    }

