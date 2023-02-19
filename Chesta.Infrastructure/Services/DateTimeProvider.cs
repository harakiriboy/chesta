using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chesta.Application.Common.Interfaces.Services;

namespace Chesta.Infrastructure.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}