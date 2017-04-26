using System.Threading;
using System.Threading.Tasks;

namespace API.Generation.Support.Repository {

    public interface IDbContextDuckType {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
