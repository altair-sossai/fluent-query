using System;
using System.Linq.Expressions;
using FluentQuery.Extensions;
using FluentQuery.Filters.Builders;

namespace FluentQuery.Filters
{
    public class Filter<T> : IFilter<T>, IFilterBuilder<T>
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

        IFilter<T> IFilterBuilder<T>.Filter => this;

        public override string ToString()
        {
            return Expression?.ToString() ?? base.ToString();
        }
    }
}