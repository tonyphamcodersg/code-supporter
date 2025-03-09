using Cassie.Domain.Common.Interfaces;
using System;

namespace Cassie.Domain.Common.EntityDefinition
{
    public abstract class AuditableEntity<TUser> : IAuditableEntity<TUser>
    {
        public TUser CreatedBy { get; set; }
        public DateTimeOffset Created { get; set; }
        public TUser LastModifiedBy { get; set; }
        public DateTimeOffset? LastModified { get; set; }
    }
}
