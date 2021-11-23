using FluentQuery.Filters.Operations;

namespace FluentQuery.UnitTest.Entities
{
    public class ProductQuery : AbstractQuery<Product>
    {
        public ProductQuery()
        {
            FilterFor(f => f.Title)
                .IsNotNull()
                .And()
                .StartsWith("M")
                .Or()
                .StartsWith("T");
        }
    }
}