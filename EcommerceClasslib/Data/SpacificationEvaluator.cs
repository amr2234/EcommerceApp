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
    internal class SpacificationEvaluator<TEntitiy> where TEntitiy : BaseClass
    {
        public static IQueryable<TEntitiy> GetQuery(IQueryable<TEntitiy> inputQuery,
            ISpacification<TEntitiy> Spac)
        {
            var query = inputQuery;
            if(Spac.Criteria != null)  query = query.Where(Spac.Criteria);

            query = Spac.Includes.Aggregate
                (query,(current,include)=>current.Include(include));
            return query;
        }

    }
}
