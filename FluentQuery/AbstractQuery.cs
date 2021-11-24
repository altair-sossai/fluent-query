using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using FluentQuery.Filters;
using FluentQuery.Filters.Builders;

namespace FluentQuery
{
    public abstract class AbstractQuery<T>
    {
        private readonly List<IFilter<T>> _filters;

        protected AbstractQuery()
        {
            _filters = new List<IFilter<T>>();
        }

        public IFilter<T> Where(Expression<Func<T, bool>> expression)
        {
            var filter = new Filter<T>(expression);

            _filters.Add(filter);

            return filter;
        }

        public IFilterBuilder<T, TProperty> FilterFor<TProperty>(Expression<Func<T, TProperty>> property)
        {
            var builder = new FilterBuilder<T, TProperty>(property);

            _filters.Add(builder.Filter);

            return builder;
        }

        public IQueryable<T> ApplyQuery(IQueryable<T> queryable)
        {
            foreach (var filter in _filters)
                queryable = queryable.Where(filter.Expression);

            return queryable;
        }
    }
}