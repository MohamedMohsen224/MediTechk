using Core.Models;
using Core.Reposatries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public  interface IUnitOfwork :IAsyncDisposable
    {
        IGenaricReposatry<TEntity> Repository<TEntity>() where TEntity : class;
        Task<int> CompleteAsync();
    }
}
