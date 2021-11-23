using FluentQuery.Filters.Builders;
using FluentQuery.Filters.Operator;

namespace FluentQuery.Filters.Operations
{
    public static class IsFalseOperation
    {
        public static ILogicalOperator<T, bool> IsFalse<T>(this IFilterBuilder<T, bool> filter)
        {
            return filter.Equal(false);
        }
    }
}