using LojaQuadrinhos.Domain.Entities;
using LojaQuadrinhos.Infra.Context;
using LojaQuadrinhos.Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LojaQuadrinhos.Infra.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : Base
    {
        private readonly ModelContext _context;
        public BaseRepository(ModelContext context)
        {
            _context = context;
        }

        public virtual async Task<T> Create(T obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();

            return obj;
        }

        public virtual async Task<T> Update(T obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            
            return obj;
        }

        public virtual async Task<T> Get(int id)
        {
            var obj = await _context
                                .Set<T>()
                                .AsNoTracking()
                                .Where(obj => obj.Id == id)
                                .FirstOrDefaultAsync();

            return obj;
        }

        public virtual async Task<List<T>> GetAll()
        {
            var obj = await _context.Set<T>().AsNoTracking().ToListAsync();

            return obj;
        }

        public virtual async Task Remove(int id)
        {
            var obj = await Get(id);

            if(obj != null)
            {
                _context.Remove(obj);
                await _context.SaveChangesAsync();
            }
        }
    }
}
