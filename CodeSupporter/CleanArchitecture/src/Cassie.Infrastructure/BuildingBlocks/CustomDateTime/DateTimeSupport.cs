using Cassie.Application.Common.Interfaces;
using System;

namespace Cassie.Infrastructure.BuildingBlocks.CustomDateTime
{
    public class DateTimeSupport : IDateTimeSupport, ITransientService
    {
        public DateTimeOffset Now => DateTimeOffset.Now;
    }
}
