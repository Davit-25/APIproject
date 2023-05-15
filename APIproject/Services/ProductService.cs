using APIproject.Interfaces;
using APIproject.Models;
using Microsoft.EntityFrameworkCore;
using APIproject.Mapping;
using APIproject.Entity;
using APIproject;

namespace APIproject.Services
{
    public class ProductService
    {
        private readonly ProductManagmentContext _context;
        private readonly IProductMapper<Entity.Product, ProductModel> _productMapper;
      

        public ProductService(ProductManagmentContext context)
        {
            _productMapper = new ProductMapper();
            _context = context;
        }
        public CreateProductResponse CreateProduct(ProductModel product)
        {
            var CategoryAlreadytExists = _context.Categories.Any(p => p.ID == product.ID);
            if (CategoryAlreadytExists)
            {
                throw new DbUpdateException($"categoy with ID{product.ID} already exist");

            }
            var productEntity = _productMapper.mapFromModeltoEntitylProdcut(product);
            var newProduct = _context.Products.Add(productEntity);

            _context.SaveChanges();
            return new CreateProductResponse { createProductModel=product };
        }

        public GetProductResponse GetProduct(GetProductRequest getProductRequest)
        {
            var product = _context.Products.Find(getProductRequest.ID);

            return new GetProductResponse { getProductModel = _productMapper.mapFromEntitytoModelProduct(product) };
        }

        public UpdateProductResponse UpDateProduct(UpdateProductRequest upDateProductRequest)
        {
            var existingProductToUpdate = _context.Products.Find(upDateProductRequest.productToUpdate.ID);

            if (existingProductToUpdate == null)
            {
                throw new DbUpdateException("There is no such ID");
            }

            _productMapper.mapFromModeltoEntitylProduct(upDateProductRequest.productToUpdate, existingProductToUpdate);

            _context.SaveChanges();
            return new UpdateProductResponse { updateProductModel = upDateProductRequest.productToUpdate };
        }
        public DeleteProductResponse DeleteProduct(DeleteProductRequest deleteProductRequest)
        {
            var product = _context.Products.Find(deleteProductRequest.ID);
            if (product == null)
            {
                throw new DbUpdateException($"Product with ID{deleteProductRequest.ID} does not exist");
            }
            _context.Products.Remove(product);
            _context.SaveChanges();
            return new DeleteProductResponse();
        }
    }
   
}
