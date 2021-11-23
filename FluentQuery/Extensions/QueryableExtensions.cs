using System.Collections.Generic;
using System.Linq;

namespace FluentQuery.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> ApplyQuery<T>(this IEnumerable<T> enumerable, AbstractQuery<T> query)
        {
            var queryable = enumerable.AsQueryable();

            return queryable.ApplyQuery(query);
        }

        public static IQueryable<T> ApplyQuery<T>(this IQueryable<T> queryable, AbstractQuery<T> query)
        {
            return query.ApplyQuery(queryable);
        }
    }
}