using StoreP.Core.Entities;
using StoreP.Core.Repositories.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreP.Core
{
    public interface IUnitOfWork
    {
        Task<int> CompliteAsync();
        
        // Create Repository<T> and Return

        IGenericRepository<TEntity , TKey> Repsitory<TEntity , TKey>() where TEntity : BaseEntity<TKey>;
    }
}
