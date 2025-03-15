using Cassie.Domain.Common.Interfaces;

namespace Cassie.Domain.Common.EntityDefinition
{
    public abstract class Entity<TPrimaryKey> : IEntityId<TPrimaryKey>
    {
        public TPrimaryKey Id { get; set; }
    }
}
