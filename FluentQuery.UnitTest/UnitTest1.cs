using System;
using System.Collections.Generic;
using System.Linq;
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
                new Product {Name = "01", Amount = 10, Actived = false, Category = new Category {Actived = false}},
                new Product {Name = "02", Amount = 11, Actived = false, Category = new Category {Actived = false}},
                new Product {Name = "03", Amount = 8, Actived = true, Category = new Category {Actived = true}},
                new Product {Name = "04", Amount = 5, Actived = true, Category = new Category {Actived = true}},
                new Product {Name = "05", Amount = 4, Actived = false, Category = new Category {Actived = true}}
            };

            var productQuery = new ProductQuery();

            foreach (var product in productQuery.ExecuteQuery(products.AsQueryable()).ToList())
                Console.WriteLine(product.Name);
        }
    }
}