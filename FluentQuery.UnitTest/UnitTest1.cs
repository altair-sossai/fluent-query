using System;
using System.Collections.Generic;
using FluentQuery.Extensions;
using FluentQuery.UnitTest.Entities;
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
                new Product
                {
                    Id = 1,
                    Title = "Mouse",
                    Active = true,
                    Category = new Category {Id = 3}
                },
                new Product
                {
                    Id = 2,
                    Title = "Keyboard",
                    Active = true,
                    Category = new Category {Id = 3}
                },
                new Product
                {
                    Id = 3,
                    Active = false,
                    Category = new Category {Id = 1}
                },
                new Product
                {
                    Id = 4,
                    Active = true,
                    Category = new Category {Id = 2}
                },
                new Product
                {
                    Id = 5,
                    Active = false,
                    Category = new Category {Id = 2}
                }
            };

            var query = new ProductQuery();

            foreach (var product in products.ApplyQuery(query))
                Console.WriteLine(product.Id);
        }
    }
}