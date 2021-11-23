using System;
using System.Linq.Expressions;

namespace FluentQuery.Filters
{
    public class Filter<T> : IFilter<T>
    {
        public Filter(Expression<Func<T, bool>> expression)
        {
            Expression = expression;
        }

        public Expression<Func<T, bool>> Expression { get; }
    }
}