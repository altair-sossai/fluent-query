using FluentQuery.Filters.Operations;

namespace FluentQuery.UnitTest.Entities
{
    public class ProductQuery : AbstractQuery<Product>
    {
        public ProductQuery()
        {
            Where(w => w.Id == 1 && w.Active)
                .And(a => a.Title == "Oi")
                .And(f => f.Category != null)
                .And(b => b.Category.Id == b.Id)
                .And(c => c.Id > 10)
                .And(d => d.Active);

            FilterFor(f => f.Active)
                .IsTrue()
                .Or()
                .IsTrue();

            FilterFor(f => f.Title)
                .IsNotNull()
                .And()
                .StartsWith("M");
        }
    }
}