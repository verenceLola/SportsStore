using System.Collections.Generic;

namespace SportsStore.Models {
    public class EFProductRepository : IProductRepository {
        private ApplicationDBContext context;
        public EFProductRepository(ApplicationDBContext ctx){
            context = ctx;
        }
        public IEnumerable<Product> Products => context.Products;
    }
}