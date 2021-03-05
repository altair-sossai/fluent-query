using System;

namespace FluentQuery
{
    public class ProductQuery : AbstractQuery<Product>
    {
        public ProductQuery()
        {
            QueryFor(f => f.Actived)
                .IsTrue();

            QueryFor(f => f.Actived)
                .IsFalse();
        }
    }

    public abstract class AbstractQuery<T>
    {
        protected QueryBuilder<T> QueryFor(Func<T, bool> func)
        {
            return null;
        }
    }

    public class QueryBuilder<T, TP>
    {
    }

    public class QueryBuilder<T> : QueryBuilder<T, bool>
    {
        public QueryBuilder<T> IsTrue()
        {
            return this;
        }

        public QueryBuilder<T> IsFalse()
        {
            return this;
        }
    }

    public class ProductQueryCommand
    {
        public Guid Id { get; set; }
    }

    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime Created { get; set; }
        public Color Color { get; set; }
        public bool Actived { get; set; }
    }

    public enum Color
    {
        Red,
        White,
        Black
    }
}