namespace FluentQuery.Filters.Operations
{
    public static class IsFalseOperation
    {
        public static IFilter<T, bool> IsFalse<T>(this IFilter<T, bool> filter)
        {
            return filter.Equal(false);
        }
    }
}