using System;
using System.Linq;
using System.Linq.Expressions;

namespace FluentQuery.Filters.Operations
{
    public static class IsNotNullOperation
    {
        public static IFilter<T, TProperty> IsNotNull<T, TProperty>(this IFilter<T, TProperty> filter)
        {
            var property = filter.Property.Body;
            var constant = Expression.Constant(null, typeof(TProperty));
            var operation = Expression.NotEqual(property, constant);
            var parameters = filter.Property.Parameters;
            var parameter = parameters.First();
            var expression = Expression.Lambda<Func<T, bool>>(operation, parameter);

            filter.Expression = expression;

            return filter;
        }
    }
}