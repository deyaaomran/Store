using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreP.Core.Entities
{
    public class BaseEntity<TKey>
    {
        public TKey Id { get; set; }
        public DateTime CraetedaAt { get; set; } = DateTime.UtcNow;
    }
}
