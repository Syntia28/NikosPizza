using System.Linq.Expressions;
using NikosPizza.core;

namespace NikosPizza.Application.Repositories
{
    public interface IRepositoryBase<T> where T : EntityBase
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate);
    }
}
