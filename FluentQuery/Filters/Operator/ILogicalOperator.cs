using FluentQuery.Filters.Builders;

namespace FluentQuery.Filters.Operator
{
    public interface ILogicalOperator<T, TProperty>
    {
        IFilterBuilder<T, TProperty> And();
        IFilterBuilder<T, TProperty> Or();
    }
}