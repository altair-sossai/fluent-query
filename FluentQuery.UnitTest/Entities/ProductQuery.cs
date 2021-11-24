using FluentQuery.Filters.Operations;

namespace FluentQuery.UnitTest.Entities
{
    public class ProductQuery : AbstractQuery<Product>
    {
        public ProductQuery()
        {
            Where(w => w.Active);

            FilterFor(f => f.Active)
                .IsTrue()
                .Or()
                .IsNull();

            FilterFor(f => f.Title)
                .IsNotNull()
                .And()
                .StartsWith("M")
                .Or()
                .StartsWith("T");
        }
    }
}