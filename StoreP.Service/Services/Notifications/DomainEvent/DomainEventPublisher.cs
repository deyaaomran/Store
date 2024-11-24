using StoreP.Core.Repositories.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StoreP.Service.Services.Notifications.DomainEvent
{
    public class DomainEventPublisher
    {
        private readonly IServiceProvider _serviceProvider;

        public DomainEventPublisher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public async Task Publish<TEvent>(TEvent domainEvent) where TEvent : IDomainEvent
        {
            var handlers = (IEnumerable<IDomainEventHandler<TEvent>>) _serviceProvider.GetService(typeof(IEnumerable<IDomainEventHandler<TEvent>>));

            foreach (var handler in handlers)
            {
                await handler.Handle(domainEvent);
            }
        }
    }
}
