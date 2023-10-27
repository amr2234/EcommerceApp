using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Core.Entities;
using E_Core.Spacification;
using Microsoft.EntityFrameworkCore;

namespace EcommerceClasslib.Data
{
    public class SpacificationEvaluator<TEntitiy> where TEntitiy : BaseClass
    {
        public static IQueryable<TEntitiy> GetQuery(IQueryable<TEntitiy> inputQuery,
            ISpacification<TEntitiy> Spac)
        {
            var query = inputQuery;
            if(Spac.Criteria != null)  query = query.Where(Spac.Criteria);


            if (Spac.OrderBy != null)
            {
                query = query.OrderBy(Spac.OrderBy);
            }
            if (Spac.OrderByDesending != null)
            {
                query = query.OrderByDescending(Spac.OrderByDesending);
            }


            if (Spac.IsPagingEnabled)
            {
                query = query.Skip(Spac.Skip).Take(Spac.Take);
            }





            query = Spac.Includes.Aggregate
                (query, (current, include) => current.Include(include));


            return query;


        }

    }
}
