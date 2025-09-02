using DataAccessLayer.Context;
using DataAccessLayer.Entities;
using DataAccessLayer.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class ProductRepository : IProductRepository
    {

        private readonly ApplicationDbContext _dbContext;
        public ProductRepository(ApplicationDbContext dbContext) 
        { 
            _dbContext = dbContext;
        }

        public async Task<List<Product>> GetProducts()
        {

           return await _dbContext.Products.ToListAsync();
                
        }

        public async Task<List<Product>> GetProductsByCondition(Expression<Func<Product, bool>> conditionalExpression)
        {
            return await _dbContext.Products.Where(conditionalExpression).ToListAsync();
        }
        public async Task<Product?> GetProductByCondition(Expression<Func<Product, bool>> conditionalExpression)
        {
            return await _dbContext.Products.Where(conditionalExpression).SingleOrDefaultAsync();
        }
        public async Task<Product?> AddProduct(Product product)
        {
             _dbContext.Products.Add(product);
             await _dbContext.SaveChangesAsync();
             return product;    
        }
        public async Task<Product?> UpdateProduct(Product product)
        {
           Product? existingProduct = _dbContext.Products.FirstOrDefault(x => x.ProductId ==product.ProductId);
            if (existingProduct != null)
                return null;
            else
            {
                existingProduct.ProductName = product.ProductName;
                existingProduct.Category = product.Category;
                existingProduct.UnitPrice= product.UnitPrice;   
                existingProduct.QuantityInStock = product.QuantityInStock;
                
            }

            _dbContext.Products.Update(existingProduct);    
            await _dbContext.SaveChangesAsync();    
            return product;

        }
        public async Task<bool> DeleteProduct(Guid productId)
        {

            Product existingProduct = _dbContext.Products.FirstOrDefault(x => x.ProductId == productId);
            if (existingProduct != null)
            {
                return false;
            }
                
            _dbContext.Products.Remove(existingProduct);
            await _dbContext.SaveChangesAsync();    
            return true;

        }
    }
}
