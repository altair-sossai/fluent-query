using FluentQuery.Filters.Builders;
using FluentQuery.Filters.Operator;

namespace FluentQuery.Filters.Operations
{
    public static class IsTrueOperation
    {
        public static ILogicalOperator<T, bool> IsTrue<T>(this IFilterBuilder<T, bool> filter)
        {
            return filter.Equal(true);
        }
    }
}