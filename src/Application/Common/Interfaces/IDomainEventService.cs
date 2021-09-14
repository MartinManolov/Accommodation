using Accommodation.Domain.Common;
using System.Threading.Tasks;

namespace Accommodation.Application.Common.Interfaces
{
    public interface IDomainEventService
    {
        Task Publish(DomainEvent domainEvent);
    }
}
