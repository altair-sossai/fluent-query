using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FluentQuery
{
    public class ProductQuery : AbstractQuery<Product>
    {
        public ProductQuery()
        {
            QueryFor(f => f.Amount)
                .GreaterThan(8);
        }
    }

    public abstract class AbstractQuery<T> : IExecuterQuery<T>
    {
        private readonly List<IExecuterQuery<T>> _executers = new List<IExecuterQuery<T>>();

        public IQueryable<T> ExecuteQuery(IQueryable<T> queryable)
        {
            foreach (var executer in _executers)
                queryable = executer.ExecuteQuery(queryable);

            return queryable;
        }

        protected BooleanQueryBuilder<T> QueryFor(Expression<Func<T, bool>> expression)
        {
            var builder = new BooleanQueryBuilder<T>(expression);

            _executers.Add(builder);

            return builder;
        }

        protected Int32QueryBuilder<T> QueryFor(Expression<Func<T, int>> expression)
        {
            var builder = new Int32QueryBuilder<T>(expression);

            _executers.Add(builder);

            return builder;
        }
    }

    public interface IExecuterQuery<T>
    {
        public IQueryable<T> ExecuteQuery(IQueryable<T> queryable);
    }

    public abstract class AbstractQueryBuilder<T, TProperty> : IExecuterQuery<T>
    {
        protected readonly Expression<Func<T, TProperty>> Property;

        protected AbstractQueryBuilder(Expression<Func<T, TProperty>> property)
        {
            Property = property;
        }

        public abstract IQueryable<T> ExecuteQuery(IQueryable<T> queryable);
    }

    public class BooleanQueryBuilder<T> : AbstractQueryBuilder<T, bool>
    {
        private bool _currentValue = true;

        public BooleanQueryBuilder(Expression<Func<T, bool>> property)
            : base(property)
        {
        }

        public BooleanQueryBuilder<T> IsTrue()
        {
            _currentValue = true;

            return this;
        }

        public BooleanQueryBuilder<T> IsFalse()
        {
            _currentValue = false;

            return this;
        }

        public override IQueryable<T> ExecuteQuery(IQueryable<T> queryable)
        {
            var parameters = Property.Parameters;
            var parameter = parameters.First();
            var parameterExpression = Expression.Parameter(typeof(T), parameter.Name);
            var constantExpression = Expression.Constant(_currentValue, typeof(bool));
            var invocationExpression = Expression.Invoke(Property, parameterExpression);
            var binaryExpression = Expression.Equal(invocationExpression, constantExpression);
            var expression = Expression.Lambda<Func<T, bool>>(binaryExpression, parameterExpression);

            return queryable.Where(expression);
        }
    }

    public class Int32QueryBuilder<T> : AbstractQueryBuilder<T, int>
    {
        private readonly ParameterExpression _parameterExpression;
        private BinaryExpression _binaryExpression;

        public Int32QueryBuilder(Expression<Func<T, int>> property)
            : base(property)
        {
            var parameters = Property.Parameters;
            var parameter = parameters.First();

            _parameterExpression = Expression.Parameter(typeof(T), parameter.Name);
        }

        public Int32QueryBuilder<T> EqualTo(int value)
        {
            var constantExpression = Expression.Constant(value, typeof(int));
            var invocationExpression = Expression.Invoke(Property, _parameterExpression);

            _binaryExpression = Expression.Equal(invocationExpression, constantExpression);

            return this;
        }

        public Int32QueryBuilder<T> GreaterThanOrEqualTo(int value)
        {
            var constantExpression = Expression.Constant(value, typeof(int));
            var invocationExpression = Expression.Invoke(Property, _parameterExpression);

            _binaryExpression = Expression.GreaterThanOrEqual(invocationExpression, constantExpression);

            return this;
        }

        public Int32QueryBuilder<T> GreaterThan(int value)
        {
            var constantExpression = Expression.Constant(value, typeof(int));
            var invocationExpression = Expression.Invoke(Property, _parameterExpression);

            _binaryExpression = Expression.GreaterThan(invocationExpression, constantExpression);

            return this;
        }

        public override IQueryable<T> ExecuteQuery(IQueryable<T> queryable)
        {
            if (_binaryExpression == null)
                return queryable;

            var expression = Expression.Lambda<Func<T, bool>>(_binaryExpression, _parameterExpression);

            return queryable.Where(expression);
        }
    }

    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public DateTime Created { get; set; }
        public Color Color { get; set; }
        public bool Actived { get; set; }
        public Category Category { get; set; }
    }

    public class Category
    {
        public bool Actived { get; set; }
    }

    public enum Color
    {
        Red,
        White,
        Black
    }
}