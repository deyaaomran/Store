﻿using Microsoft.EntityFrameworkCore;
using StoreP.Core.Entities;
using StoreP.Core.Repositories.Contract;
using StoreP.Repository.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreP.Repository.Repositories
{
    public class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        private readonly StoreDbContext _context;
        public GenericRepository(StoreDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            if(nameof(TEntity) == nameof(Product))
            {
                return (IEnumerable<TEntity>) await _context.Products.Include(P => P.Brand).Include(P => P.Type).ToListAsync();
            }
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetAsync(TKey id)
        {
            if (nameof(TEntity) == nameof(Product))
            {
                return await _context.Products.Include(P => P.Brand).Include(P => P.Type).FirstOrDefaultAsync(P => P.Id == id as int?) as TEntity;
            }
            return await _context.Set<TEntity>().FindAsync(id);
        }
        public async Task AddAsync(TEntity entity)
        {
            await _context.AddAsync(entity);

        }

        public void Delete(TEntity entity)
        {
             _context.Remove(entity);
        }

        public void Update(TEntity entity)
        {
            _context.Update(entity);
        }
    }
}