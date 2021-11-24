using System;
using System.Linq.Expressions;
using FluentQuery.Filters.Extensions;

namespace FluentQuery.Filters
{
    public class Filter<T> : IFilter<T>
    {
        public Filter(Expression<Func<T, bool>> expression)
        {
            Expression = expression;
        }

        public Expression<Func<T, bool>> Expression { get; private set; }

        public IFilter<T> And(Expression<Func<T, bool>> expression)
        {
            Expression = Expression.AndAlso(expression);

            return this;
        }

        public IFilter<T> Or(Expression<Func<T, bool>> expression)
        {
            Expression = Expression.OrElse(expression);

            return this;
        }
    }
}