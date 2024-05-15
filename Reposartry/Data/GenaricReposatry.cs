using Core.Models;
using Core.Reposatries;
using Core.Specfication;
using Microsoft.EntityFrameworkCore;
using Reposartry;
using Reposatry.DAta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reposatry.Data
{
    public class GenaricReposatry<T> : IGenaricReposatry<T> where T : class
    {
        private readonly HospitalContext context;

        public GenaricReposatry(HospitalContext context)
        {

            this.context = context;
        }
        //Add
        public async Task<T> AddAsync(T entity)
        {
            context.Set<T>().Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }
        //Delete
        public async Task<T> DeleteAsync(T entity)
        {
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
            return entity;
        }
        //GetAll
        public async Task<IReadOnlyList<T>> GetAllSpecAsync(ISpecfication<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }
        //GetById
        public  async Task<T> GetByIdSpecAsync(ISpecfication<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }
        //Update
        public async Task<T> UpdateAsync(T entity)
        {
            context.Update(entity);
            await context.SaveChangesAsync();
            return entity;

        }
        //ApplySpecification
        private IQueryable<T> ApplySpecification(ISpecfication<T> spec)
        {
            return SpecifictionEvalutor<T>.GetQuery(context.Set<T>().AsQueryable(), spec);
        }
    }
}
