using System;

namespace Cassie.Domain.Common.Interfaces
{
    public interface ICreatedTimestamp
    {
        DateTimeOffset Created { get; set; }
    }
}
