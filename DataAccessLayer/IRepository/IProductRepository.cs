using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.IRepository
{
    public interface IProductRepository
    {
        Task<List<Product>>GetProducts();
        Task<List<Product>> GetProductsByCondition(Expression<Func<Product,bool>> conditionalExpression);
        Task<Product?> GetProductByCondition(Expression<Func<Product, bool>> conditionalExpression);
        Task<Product?> AddProduct(Product product);
        Task<Product?> UpdateProduct(Product product);
        Task <bool> DeleteProduct(Guid id);
   }
}
