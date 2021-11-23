﻿using System;
using System.Linq;
using System.Linq.Expressions;

namespace FluentQuery.Filters.Operations
{
    public static class GreaterThanOrEqualOperation
    {
        public static IFilter<T, TProperty> GreaterThanOrEqual<T, TProperty>(this IFilter<T, TProperty> filter, TProperty value)
        {
            var property = filter.Property.Body;
            var constant = Expression.Constant(value, typeof(TProperty));
            var operation = Expression.GreaterThanOrEqual(property, constant);
            var parameters = filter.Property.Parameters;
            var parameter = parameters.First();
            var expression = Expression.Lambda<Func<T, bool>>(operation, parameter);

            filter.Expression = expression;

            return filter;
        }
    }
}