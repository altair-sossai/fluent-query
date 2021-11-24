using System;
using System.Linq;
using System.Linq.Expressions;
using FluentQuery.Extensions;

namespace FluentQuery.Filters.Extensions
{
    public static class ExpressionExtensions
    {
        public static Expression<Func<T, bool>> AndAlso<T>(this Expression<Func<T, bool>> left, Expression<Func<T, bool>> right)
        {
            var parameters = left.Parameters;
            var parameter = parameters.First();
            var rightExpression = right.ReplaceParameter(parameter);
            var andAlso = Expression.AndAlso(left.Body, rightExpression.Body);
            var expression = Expression.Lambda<Func<T, bool>>(andAlso, parameter);

            return expression;
        }

        public static Expression<Func<T, bool>> OrElse<T>(this Expression<Func<T, bool>> left, Expression<Func<T, bool>> right)
        {
            var parameters = left.Parameters;
            var parameter = parameters.First();
            var rightExpression = right.ReplaceParameter(parameter);
            var orElse = Expression.OrElse(left.Body, rightExpression.Body);
            var expression = Expression.Lambda<Func<T, bool>>(orElse, parameter);

            return expression;
        }
    }
}