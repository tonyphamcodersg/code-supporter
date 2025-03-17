using Cassie.Application.Common.Interfaces;
using Cassie.DependencyInjection.Extensions.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Cassie.Infrastructure.Persistence
{
    public abstract class CassieDbContext : DbContext, ICassieDbContext, IScopedService
    {
        private readonly ICurrentUser _currentUser;

        public CassieDbContext(DbContextOptions options, ICurrentUser currentUser) : base(options)
        {
            _currentUser = currentUser ?? throw new ArgumentNullException(nameof(ICurrentUser));
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
