using System;
using System.Linq;
using System.Linq.Expressions;

namespace FluentQuery.Filters.Operations
{
    public static class LessThanOrEqualOperation
    {
        public static IFilter<T, TProperty> LessThanOrEqual<T, TProperty>(this IFilter<T, TProperty> filter, TProperty value)
        {
            var property = filter.Property.Body;
            var constant = Expression.Constant(value, typeof(TProperty));
            var operation = Expression.LessThanOrEqual(property, constant);
            var parameters = filter.Property.Parameters;
            var parameter = parameters.First();
            var expression = Expression.Lambda<Func<T, bool>>(operation, parameter);

            filter.Expression = expression;

            return filter;
        }
    }
}