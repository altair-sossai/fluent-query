﻿using System;
using System.Linq;
using System.Linq.Expressions;
using FluentQuery.Filters.Builders;
using FluentQuery.Filters.Operator;

namespace FluentQuery.Filters.Operations
{
    public static class NotEqualOperation
    {
        public static ILogicalOperator<T, TProperty> NotEqual<T, TProperty>(this IFilterBuilder<T, TProperty> filter, TProperty value)
        {
            var property = filter.Property.Body;
            var constant = Expression.Constant(value, typeof(TProperty));
            var operation = Expression.NotEqual(property, constant);
            var parameters = filter.Property.Parameters;
            var parameter = parameters.First();
            var expression = Expression.Lambda<Func<T, bool>>(operation, parameter);

            return filter.Append(expression);
        }
    }
}