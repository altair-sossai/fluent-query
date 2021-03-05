using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FluentQuery
{
    public class Main
    {
        public Main()
        {
            var products = new List<Product>();

            var query = products.Filter<ProductQuery>();
        }
    }

    public class ProductQuery : AbstractQuery<Product>
    {
        public ProductQuery()
        {
            QueryFor(f => f.Actived)
                .IsTrue();

            QueryFor(f => f.Actived)
                .IsFalse();

            QueryFor(f => f.Created)
                .GreaterOrEqualTo(DateTime.Now);
        }
    }

    public abstract class AbstractQuery<T>
    {
        protected QueryBuilder<T> QueryFor(Expression<Func<T, bool>> expression)
        {
            return new QueryBuilder<T>(expression);
        }
    }

    public class QueryBuilder<T, TProperty>
    {
        protected readonly Expression<Func<T, TProperty>> Expression;

        public QueryBuilder(Expression<Func<T, TProperty>> expression)
        {
            Expression = expression;
        }
    }

    public class QueryBuilder<T> : QueryBuilder<T, bool>
    {
        public QueryBuilder(Expression<Func<T, bool>> expression)
            : base(expression)
        {
        }

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