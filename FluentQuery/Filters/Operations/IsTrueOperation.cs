namespace FluentQuery.Filters.Operations
{
    public static class IsTrueOperation
    {
        public static IFilter<T, bool> IsTrue<T>(this IFilter<T, bool> filter)
        {
            return filter.Equal(true);
        }
    }
}