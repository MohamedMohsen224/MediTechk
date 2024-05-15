using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specfication
{
    public class BaseSpecfication<T> : ISpecfication<T> where T : class
    {
        public Expression<Func<T, bool>> Criteria { get; set; }
        public List<Expression<Func<T, object>>> Includes { get; set; } = new List<Expression<Func<T, object>>>();
        public Expression<Func<T, object>> OrderBy { get; set; }
        public Expression<Func<T, object>> OrderByDescending { get; set; }
        public bool IsPagingEnabled { get; set; }
        public int Skip { get; set; }
        public BaseSpecfication()
        {
        }

        public BaseSpecfication(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }
        public void AddOrderBy(Expression<Func<T, object>> orderExpression)
        {
            OrderBy = orderExpression;
        }
        public void AddOrderByDesc(Expression<Func<T, object>> orderByDescExpression)
        {
            OrderByDescending = orderByDescExpression;
        }

        public void ApplyPagination(int skip, int pageSize)
        {
            IsPagingEnabled = true;
            Skip = skip;


        }



    }

}
