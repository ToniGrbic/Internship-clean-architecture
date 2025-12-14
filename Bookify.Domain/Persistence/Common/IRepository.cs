using Bookify.Domain.Abstractions;
using Bookify.Domain.Common.Model;

namespace Bookify.Domain.Persistence.Common
{
    public interface IRepository<TEntity, TId> where TEntity : class //Entity
    {
        Task<GetAllResponse<TEntity>> Get();
        Task InsertAsync(TEntity entity);
        void Update(TEntity entity);
        Task DeleteAsync(TId id);
        void Delete(TEntity? entity);
    }
}
