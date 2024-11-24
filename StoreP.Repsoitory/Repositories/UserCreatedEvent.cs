using StoreP.Core.Repositories.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreP.Repository.Repositories
{
    public class UserCreatedEvent : IDomainEvent
    {
        public Guid UserId { get; }
        public string UserName { get; }
        public DateTime OccurredOn { get; }

        public UserCreatedEvent(Guid userId, string userName)
        {
            UserId = userId;
            UserName = userName;
            OccurredOn = DateTime.UtcNow;

        }
    }
}
