using WorkingWithVisualStudio.Models;
using Xunit;

namespace WorkingWithVisualStudio.Tests
{
    public class ProductTests
    {
        [Fact]
        public void CanChangeProductName()
        {
            //arrange
            var p = new Product { Name = "test", Price = 100M };

            //act
            p.Name = "New Name";

            //assert
            Assert.Equal("New Name", p.Name);
        }

        [Fact]
        public void CanChangeProductPrice()
        {
            //arrange
            var p = new Product { Name = "test", Price = 100M };

            //act
            p.Price = 200M;

            //assert
            Assert.Equal(200M, p.Price);
        }


    }
}
