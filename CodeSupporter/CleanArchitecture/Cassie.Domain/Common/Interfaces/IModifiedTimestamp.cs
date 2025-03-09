using System;

namespace Cassie.Domain.Common.Interfaces
{
    public interface IModifiedTimestamp
    {
        DateTimeOffset? LastModified { get; set; }
    }
}
