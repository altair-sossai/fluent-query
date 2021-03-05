using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentQuery.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var products = new List<Product>
            {
                new Product {Name = "01", Actived = false, Category = new Category {Actived = false}},
                new Product {Name = "02", Actived = false, Category = new Category {Actived = false}},
                new Product {Name = "03", Actived = true, Category = new Category {Actived = true}},
                new Product {Name = "04", Actived = true, Category = new Category {Actived = true}},
                new Product {Name = "05", Actived = false, Category = new Category {Actived = true}}
            };

            var parameterExpression = Expression.Parameter(typeof(Product));

            var memberExpression = Expression.Property(parameterExpression, nameof(Product.Actived));
            //Expression<Func<Product, bool>> memberExpression = p => p.Actived;

            var constantExpression = Expression.Constant(true, typeof(bool));
            var binaryExpression = Expression.Equal(memberExpression, constantExpression);
            var expression = Expression.Lambda<Func<Product, bool>>(binaryExpression, parameterExpression);

            foreach (var product in products.AsQueryable().Where(expression))
                Console.WriteLine(product.Name);
        }
    }
}