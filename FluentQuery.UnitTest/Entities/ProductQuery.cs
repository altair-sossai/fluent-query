using FluentQuery.Filters.Operations;

namespace FluentQuery.UnitTest.Entities
{
    public class ProductQuery : AbstractQuery<Product>
    {
        public ProductQuery()
        {
            FilterFor(f => f.Title)
                .IsNotNull()
                .And(g => g.Active)
                .IsTrue()
                .Or(g => g.Category.Id)
                .GreaterThanOrEqual(10);
        }
    }
}