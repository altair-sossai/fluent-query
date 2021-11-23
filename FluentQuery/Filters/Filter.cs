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

        public Expression<Func<T, bool>> Expression { get; set; }
    }

    public class Filter<T, TProperty> : Filter<T>, IFilter<T, TProperty>
    {
        public Filter(Expression<Func<T, TProperty>> property)
            : base(null)
        {
            Property = property;
        }

        public Expression<Func<T, TProperty>> Property { get; }
    }
}