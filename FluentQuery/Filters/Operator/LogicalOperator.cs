using FluentQuery.Filters.Builders;

namespace FluentQuery.Filters.Operator
{
    public class LogicalOperator<T, TProperty> : ILogicalOperator<T, TProperty>
    {
        private readonly IFilterBuilder<T, TProperty> _builder;

        public LogicalOperator(IFilterBuilder<T, TProperty> builder)
        {
            _builder = builder;
        }

        public IFilterBuilder<T, TProperty> And()
        {
            return new AndAlsoFilterBuilder<T, TProperty>(_builder);
        }

        public IFilterBuilder<T, TProperty> Or()
        {
            return new OrElseFilterBuilder<T, TProperty>(_builder);
        }
    }
}