using NikosPizza.core;

namespace NikosPizza.Application.Repositories
{
    public interface IRepositoryBase<T> where T : EntityBase
    {
        Task<IReadOnlyList<T>> GetAllAsync();
    }
}
