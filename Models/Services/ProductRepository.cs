using GameShop.Data;
using GameShop.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GameShop.Models.Services
{
    public class ProductRepository : IProductRepository
    {
        private GameShopDbContext dbContext;
        public ProductRepository(GameShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return dbContext.Products;
        }

        public Product? GetProductDetail(int id)
        {
            return dbContext.Products.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Product> GetTrendingProducts()
        {
            return dbContext.Products.Where(p => p.IsTrendingProduct);
        }
        public Product GetProductById(int id)
        {
            return dbContext.Products.FirstOrDefault(p => p.Id == id);
        }

    }
}
