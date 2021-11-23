using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace FluentQuery.Filters.Operations
{
    public static class StartsWithOperation
    {
        private static MethodInfo _methodInfo;
        private static Type[] _types;
        private static Type _type;

        private static Type Type => _type ??= typeof(string);
        private static Type[] Types => _types ??= new[] {Type};
        private static MethodInfo MethodInfo => _methodInfo ??= Type.GetMethod("StartsWith", Types);

        public static IFilter<T, string> StartsWith<T>(this IFilter<T, string> filter, string value)
        {
            var property = filter.Property.Body;
            var constant = Expression.Constant(value, Type);
            var operation = Expression.Call(property, MethodInfo, constant);
            var parameters = filter.Property.Parameters;
            var parameter = parameters.First();
            var expression = Expression.Lambda<Func<T, bool>>(operation, parameter);

            filter.Expression = expression;

            return filter;
        }
    }
}