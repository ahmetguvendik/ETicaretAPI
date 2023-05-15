using System;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Persistance.Contexts;
using ETicateAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace ETicaretAPI.Persistance.Repositories
{
    public class WriteRepository<T> : IWrireRepository<T> where T : BaseEntitiy
    {
        private readonly ETicaretAPIDbContext _context;
        public WriteRepository(ETicaretAPIDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AddAsync(T model)
        {
            var data =  await Table.AddAsync(model);
            return data.State == EntityState.Added;
        }

        public Task<bool> AddAsync(List<T> model)
        {
            throw new NotImplementedException();
        }

        public  Task<bool> Remove(T model)
        {
          
            return Remove(model);
        }

        public async Task<bool> Remove(int id)
        {
            var data = await Table.FindAsync(id);
            return true;
        }

        public bool Update(T model)
        {
            var data = Table.Update(model);
            return true;
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}

