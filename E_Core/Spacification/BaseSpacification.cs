using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Core.Spacification
{
    public class BaseSpacification<T> : ISpacification<T>
    {
        public BaseSpacification()
        {
            
        }

        public BaseSpacification(Expression<Func<T, bool>> criteria)
        { 
            Criteria = criteria;
        }
        public Expression<Func<T, bool>> Criteria { get; set; }

        public List<Expression<Func<T, object>>> Includes { get; set; } = 
            new List<Expression<Func<T, object>>>();

        public Expression<Func<T, object>> OrderBy { get; private set; }

        public Expression<Func<T, object>> OrderByDesending { get; private set; }

        public int Take { get; private set; }

        public int Skip { get; private set; }

        public bool IsPagingEnabled { get; private set; }

        protected void AddInclude(Expression<Func<T, object>> include)
        {
            Includes.Add(include);
        }
        protected void AddOrderBy(Expression<Func<T, object>> OrderByExpersions)
        {
            OrderBy = OrderByExpersions;
           
        }
        protected void AddOrderByDes(Expression<Func<T, object>> OrderByExpersionsDes)
        {
            OrderByDesending = OrderByExpersionsDes;

        }

        protected void ApplyPaging(int skip, int take)
        {
            Skip = skip;
            Take = take;
            IsPagingEnabled = true;
        }
    }
}
