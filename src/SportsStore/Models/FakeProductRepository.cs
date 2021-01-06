using System.Collections.Generic;
using System;

namespace SportsStore.Models
{
    public class FakeProductRepository : IProductRepository
    {
        public IEnumerable<Product> Products => new List<Product>{
            new Product {Name ="Football", Price = 25},
            new Product {Name = "Surf Board", Price = 179},
            new Product {Name = "Running shoes", Price = 95},
        };

        public void SaveProduct(Product product)
        {
            Console.WriteLine("Savng Fake Product");
        }
    }
}