using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.IServices
{
     public interface  IProductService
     {
         Task<ResponseMessage> AddNewProduct(Product product);  
         Task<ResponseMessage> UpdateExistingProduct(Product product);
         Task<ResponseMessage> GetAllProducts();
         Task<ResponseMessage> GetProductById(Guid id);
         Task<ResponseMessage> DeleteProductById(Guid id);
     }
}
