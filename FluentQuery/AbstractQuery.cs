using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using FluentQuery.Filters;

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

        public IFilter<T, TProperty> FilterFor<TProperty>(Expression<Func<T, TProperty>> property)
        {
            var filter = new Filter<T, TProperty>(property);

            _filters.Add(filter);

            return filter;
        }

        public IQueryable<T> ApplyQuery(IQueryable<T> queryable)
        {
            foreach (var filter in _filters)
                queryable = queryable.Where(filter.Expression);

            return queryable;
        }
    }
}