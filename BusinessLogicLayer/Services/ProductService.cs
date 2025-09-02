using BusinessLogicLayer.IServices;
using DataAccessLayer.Entities;
using DataAccessLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository) 
        {
            _productRepository = productRepository;
        }
        public async Task<ResponseMessage> AddNewProduct(Product product)
        {
             Product? addedProduct  =  await _productRepository.AddProduct(product);
             ResponseMessage responseMessage = new ResponseMessage()
            {
                Success = true,
                Message = "Product Added SuccessFully",
                data = addedProduct,
                StatusCode = 200

            };
            return responseMessage;
        }
       public async Task<ResponseMessage> UpdateExistingProduct(Product product)
       {
           Product? updatedProduct= await _productRepository.UpdateProduct(product);
            ResponseMessage responseMessage = new ResponseMessage()
            {
                Success = true,
                Message = "product updated successfully",
                data = updatedProduct,
                StatusCode = 200
            };

            return responseMessage;
       }
            
       public async Task<ResponseMessage> GetAllProducts()
       {
            List<Product> products = await _productRepository.GetProducts();
            ResponseMessage responseMessage = new ResponseMessage()
            {
                Success = true,
                Message = "products fetched successfully",
                data = products,
                StatusCode = 200
            };

            return responseMessage;
       }
       public async Task<ResponseMessage> GetProductById(Guid id)
       {
            Product? product = await _productRepository.GetProductByCondition(temp => temp.ProductId == id);
            ResponseMessage responseMessage = new ResponseMessage()
            {
                Success = true,
                Message = "Successfully fetch the product",
                data =product,
                StatusCode=200
            };
            return responseMessage;


        }
       public async Task<ResponseMessage> DeleteProductById(Guid id)
       {
            ResponseMessage responseMessage;
            Product? product = await _productRepository.GetProductByCondition(temp => temp.ProductId == id);
            if (product == null)
            {
                responseMessage = new ResponseMessage()
                {
                    Success = true,
                    Message = "Product not found or deleted already",
                    data = product,
                    StatusCode = 200
                };
            }

           bool isDeleted = await _productRepository.DeleteProduct(id);
            if (isDeleted)
            {

                responseMessage = new ResponseMessage()
                {
                    Success = true,
                    Message = "product deleted successfully",
                    data = product,
                    StatusCode = 200
                };
            }
            else
            {
                responseMessage = new ResponseMessage()
                {
                    Success = true,
                    Message = "product not deleted",
                    data = product,
                    StatusCode = 200
                };
            }

            return responseMessage;
        }
    }
}
