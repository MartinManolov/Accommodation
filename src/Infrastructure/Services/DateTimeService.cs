using Accommodation.Application.Common.Interfaces;
using System;

namespace Accommodation.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
