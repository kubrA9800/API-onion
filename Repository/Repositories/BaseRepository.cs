using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Exceptions;
using Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly AppDbContext _context;
        private readonly DbSet<T> _entities;
        public BaseRepository(AppDbContext context)
        {
            _context = context;
            _entities=_context.Set<T>();
        }
        public async Task CreateAsync(T entity)
        {
            ArgumentNullException.ThrowIfNull(entity);
            await _entities.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            if (entity is null) throw new NotFoundExceptions("Data not found");
            _entities.Remove(entity);
            await _context.SaveChangesAsync();  
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _entities.ToListAsync();
        }

        public async Task<T> GetAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id);
            return await _entities.FirstOrDefaultAsync(m=>m.Id==id)??throw new NullReferenceException();
        }

        public async Task UpdateAsync(T entity)
        {
            ArgumentNullException.ThrowIfNull(entity);
            _entities.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
