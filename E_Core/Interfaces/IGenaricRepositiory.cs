using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Core.Entities;
using E_Core.Spacification;

namespace E_Core.Interfaces
{
    public  interface IGenaricRepositiory<T> 
    {
        Task<T> GetItemByIdAsync(int id);
        Task<IReadOnlyList<T>> GetItemsAsync();
        Task<T> GetEntitywithSpacification(ISpacification<T> spec);
        Task<IReadOnlyList<T>> ListAsync(ISpacification<T> spec);

        Task<int> CountDataAsync(ISpacification<T> spec);

    }
}
