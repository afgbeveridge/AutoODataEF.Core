using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Generation.Support.Repository {

    public interface IBaseRepository<TContext, TEntity, TKey> {
        IEnumerable<TEntity> All { get; }
        Task<TEntity> FindAsync(TKey key, params string[] includes);
        Task<TEntity> CreateAsync(TEntity customer);
        Task<bool> UpdateAsync(TKey key, TEntity customer);
        Task<bool> DeleteAsync(TKey key);
        TKey GetKeyFromEntity(TEntity e);
    }
}
