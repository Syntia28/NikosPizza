
using Microsoft.EntityFrameworkCore;
using NikosPizza.Application.Repositories;
using NikosPizza.core;

namespace NikosPizza.Infraestructure.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : EntityBase
    {
        protected readonly PizzaDbContext _dbContext;
        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }
    }
}
