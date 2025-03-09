using System;

namespace Cassie.Domain.Common.Interfaces
{
    /// <summary>
    /// Define an datetime support for project
    /// </summary>
    public interface IDateTimeSupport
    {
        DateTimeOffset Now { get; }
    }
}
