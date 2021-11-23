using System;
using System.Linq;
using System.Linq.Expressions;

namespace FluentQuery.Filters.Extensions
{
    public static class ExpressionExtensions
    {
        public static Expression<Func<T, bool>> AndAlso<T>(this Expression<Func<T, bool>> left, Expression<Func<T, bool>> right)
        {
            var andAlso = Expression.AndAlso(left.Body, right.Body);
            var parameters = left.Parameters;
            var parameter = parameters.First();
            var expression = Expression.Lambda<Func<T, bool>>(andAlso, parameter);

            return expression;
        }

        public static Expression<Func<T, bool>> OrElse<T>(this Expression<Func<T, bool>> left, Expression<Func<T, bool>> right)
        {
            var orElse = Expression.OrElse(left.Body, right.Body);
            var parameters = left.Parameters;
            var parameter = parameters.First();
            var expression = Expression.Lambda<Func<T, bool>>(orElse, parameter);

            return expression;
        }
    }
}