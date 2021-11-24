using System;
using System.Linq;
using System.Linq.Expressions;
using FluentQuery.Expressions;

namespace FluentQuery.Extensions
{
    public static class ExpressionExtensions
    {
        public static Expression<Func<T, bool>> ReplaceParameter<T>(this Expression<Func<T, bool>> expression, ParameterExpression newParameter)
        {
            var parameters = expression.Parameters;
            var parameter = parameters.First();
            var parameterUpdateVisitor = new ParameterUpdateVisitor(parameter, newParameter);
            var body = parameterUpdateVisitor.Visit(expression.Body);

            return Expression.Lambda<Func<T, bool>>(body!, newParameter);
        }
    }
}