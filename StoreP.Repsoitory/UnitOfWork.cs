using StoreP.Core;
using StoreP.Core.Entities;
using StoreP.Core.Repositories.Contract;
using StoreP.Repository.Data.Contexts;
using StoreP.Repository.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreP.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreDbContext _context;

        private Hashtable _repsitories;

        public UnitOfWork(StoreDbContext context)
        {
            _context = context;
            _repsitories = new Hashtable();
        }
        public async Task<int> CompliteAsync() => await _context.SaveChangesAsync();
        

        public IGenericRepository<TEntity, TKey> Repsitory<TEntity, TKey>() where TEntity : BaseEntity<TKey>
        {
            var type = typeof(TEntity).Name;
            if (!_repsitories.ContainsKey(type))
            {
                var repository = new GenericRepository<TEntity , TKey>(_context);
                _repsitories.Add(type, repository);
            }
            return _repsitories[type] as IGenericRepository<TEntity, TKey>;
        }
    }
}
