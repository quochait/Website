using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WorkingWithVisualStudio.Controllers;
using WorkingWithVisualStudio.Models;
using Xunit;

namespace WorkingWithVisualStudio.Tests
{
    public class HomeControllerTests
    {
        public class ModelCompleteFakeRepository: IRepository
        {
            public IEnumerable<Product> Products { get; set; }

            public void AddProduct(Product product) { }

        }

        [Theory]
        [InlineData(275, 48.95, 19.50, 24.95)]
        [InlineData(5, 48.95, 19.50, 24.95)]

        public void IndexActionModelIsComplete(decimal prices1, decimal prices2, decimal prices3, decimal prices4)
        {
            //arrange
            var controller = new HomeController();
            controller.Repository = new ModelCompleteFakeRepository {
                Products = new Product[]
                {
                    new Product {Name = "p1", Price = prices1},
                    new Product {Name = "p2", Price = prices2},
                    new Product {Name = "p3", Price = prices3},
                    new Product {Name = "p4", Price = prices4}
                }
            };

            //act
            var model = (controller.Index1() as ViewResult)?.ViewData.Model as IEnumerable<Product>;

            //assert
            Assert.Equal(controller.Repository.Products, model, Comparer.Get<Product>((p1, p2) => p1.Name == p2.Name && p1.Price == p2.Price));
        }

        class ModelCompleteFakeRepositoryPricesUnder50 : IRepository
        {
            public IEnumerable<Product> Products { get; } = new Product[]
            {
                new Product { Name = "p1", Price = 5M},
                new Product { Name = "p2", Price = 48.95M},
                new Product { Name = "p3", Price = 19.50M},
                new Product { Name = "p3", Price = 34.95M}
            };

            public void AddProduct(Product product){}
        }

        [Fact]
        public void IndexActionModelIsCompletePricesUnder50()
        {
            //arrange
            var controller = new HomeController();
            controller.Repository = new ModelCompleteFakeRepositoryPricesUnder50();

            //act
            var model = (controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Product>;

            //assert
            Assert.Equal(controller.Repository.Products, model, Comparer.Get<Product>((p1, p2) => p1.Name == p2.Name && p1.Price == p2.Price));
        }
    }
}
