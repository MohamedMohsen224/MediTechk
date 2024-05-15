using Core.Models;
using Core.Specfication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Reposatries
{
    public interface IGenaricReposatry <T> where T : class
    {
        //Task<T> GetByIdAsync(int id);
        //Task<IReadOnlyList<T>> GetAllAsync();
        Task<IReadOnlyList<T>> GetAllSpecAsync(ISpecfication<T> spec);
        Task< T> GetByIdSpecAsync(ISpecfication<T> spec);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);
    }
}
