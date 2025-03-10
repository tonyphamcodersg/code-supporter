using System.Threading;
using System.Threading.Tasks;

namespace Cassie.Application.Common.Interfaces
{
    public interface ICassieDbContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
