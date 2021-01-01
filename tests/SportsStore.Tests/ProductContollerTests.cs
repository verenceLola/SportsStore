using System.Collections.Generic;
using System.Linq;
using Moq;
using SportsStore.Controllers;
using Xunit;
using SportsStore.Models;

namespace SportsStore.Tests
{
    public class ProductContollerTests
    {
        [Fact]
        public void Can_Paginate()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[] {
                new Product {ProductID = 1, Name = "P1"},
                new Product {ProductID = 2, Name = "P2"},
                new Product {ProductID = 3, Name = "P3"},
                new Product {ProductID = 4, Name = "P4"},
                new Product {ProductID = 5, Name = "P5"},
            });


            ProductController contoller = new ProductController(mock.Object);
            contoller.PageSize = 3;

            IEnumerable<Product> result = contoller.List(2).ViewData.Model as IEnumerable<Product>;
            Product[] prodArray = result.ToArray();
            Assert.True(prodArray.Length == 2);
            Assert.Equal("P4", prodArray[0].Name);
            Assert.Equal("P5", prodArray[1].Name);
        }
    }
}