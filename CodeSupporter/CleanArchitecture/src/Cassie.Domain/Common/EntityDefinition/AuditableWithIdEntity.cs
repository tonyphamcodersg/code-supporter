using Cassie.Domain.Common.Interfaces;

namespace Cassie.Domain.Common.EntityDefinition
{
    public abstract class AuditableWithIdEntity<TUser, TPrimaryKey> : AuditableEntity<TUser>, IEntityId<TPrimaryKey>
    {
        public TPrimaryKey Id { get; set; }
    }
}
