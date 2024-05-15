using Core;
using Core.Models;
using Core.Reposatries;
using Microsoft.EntityFrameworkCore;
using Reposatry.Data;
using Reposatry.DAta;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reposatry
{
    public class UnitOfwork : IUnitOfwork
    {
        private readonly HospitalContext context;
        private Hashtable Reposatry;

        public UnitOfwork(HospitalContext context)
        {
            this.context = context;
            this.Reposatry = new Hashtable();
        }

        public async Task<int> CompleteAsync()
         => await context.SaveChangesAsync();

        public async ValueTask DisposeAsync()
         => await context.DisposeAsync();

        public IGenaricReposatry<TEntity> Repository<TEntity>() where TEntity : class
        {
            var key = typeof(TEntity).Name;

            if (!Reposatry.ContainsKey(key))
            {
                var repository = new GenaricReposatry<TEntity>(context);

                Reposatry.Add(key, repository);
            }

            return Reposatry[key] as IGenaricReposatry<TEntity>;
        }
    }
}
