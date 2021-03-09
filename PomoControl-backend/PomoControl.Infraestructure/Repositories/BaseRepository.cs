using Microsoft.EntityFrameworkCore;
using PomoControl.Core.Exceptions;
using PomoControl.Domain;
using PomoControl.Infraestructure.Context;
using PomoControl.Infraestructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PomoControl.Infraestructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : Base
    {
        private readonly PomoContext _context;
        public BaseRepository(PomoContext context)
        {
            _context = context;
        }
        public virtual async Task<T> Delete(int code)
        {
            var entity = await GetByCode(code);
            if (entity != null)
            {
                _context.Remove(entity);
                await _context.SaveChangesAsync();
            }

            return entity;
        }

        public async Task<List<T>> GetAll()
        {
            var list = await _context.Set<T>()
                .AsNoTracking()
                .ToListAsync();

            return list;
        }

        public async Task<T> GetByCode(int code)
        {
            var list = await _context.Set<T>()
                .AsNoTracking()
                .Where(x => x.Code == code)
                .ToListAsync();

            return list.FirstOrDefault();
        }

        public virtual async Task<T> Create(T entity)
        {
            try
            {
                _context.Add(entity);
                await _context.SaveChangesAsync();

                return entity;
            }
            catch (RepositoryException ex)
            {
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public virtual async Task<T> Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
