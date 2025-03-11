using System;

namespace Cassie.Application.Common.Interfaces
{
    /// <summary>
    /// Define an datetime support for project
    /// </summary>
    public interface IDateTimeSupport
    {
        DateTimeOffset Now { get; }
    }
}
