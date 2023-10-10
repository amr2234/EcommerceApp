using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Core.Entities;
using E_Core.Interfaces;
using E_Core.Spacification;
using EcommerceClasslib.DBContext;
using Microsoft.EntityFrameworkCore;

namespace EcommerceClasslib.Data
{
    public class GenaricRepository<T> : IGenaricRepositiory<T> where T : BaseClass
    {
        private readonly EContext _context;

        public GenaricRepository(EContext context)
        {
            _context = context;
        }

    

        public async Task<T> GetItemByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> GetItemsAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> ListAsync(ISpacification<T> spec)
        {
            return await ApplySpacification(spec).ToListAsync();
        }
        public async Task<T> GetEntitywithSpacification(ISpacification<T>  spec)
        {
            return await ApplySpacification(spec).FirstOrDefaultAsync();
        }

        private IQueryable<T> ApplySpacification(ISpacification<T> Spec)
        {
            return SpacificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), Spec);
        }
    }
}
