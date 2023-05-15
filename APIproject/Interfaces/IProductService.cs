using APIproject.Models;

namespace APIproject.Interfaces
{
    public interface IProductService
    {
        CreateProductResponse CreateProduct(CreateProductRequest product);
        GetProductResponse GetProduct(GetProductRequest product);
        UpdateProductResponse UpdateProduct(UpdateProductRequest product);
        DeleteProductResponse DeleteProduct(DeleteProductRequest product);
    }
}
