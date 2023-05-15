using Microsoft.AspNetCore.Http;
using APIproject.Entity;
using APIproject.Interfaces;
using APIproject.Models;
using Microsoft.AspNetCore.Mvc;
using APIproject.Services;

namespace APIproject.Controllers
{
    [Route("controller")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly ProductManagmentContext _context;
        private readonly IProductService _productService;


        public ProductController(ProductManagmentContext context, IProductService productService)
        {
            _context = context;
            _productService = productService;
        }

        [HttpPost("createProduct")]
        public CreateProductResponse CreateProduct(CreateProductRequest createRequest) => _productService.CreateProduct(createRequest);

        [HttpGet("getProduct")]
        public GetProductResponse GetProduct(GetProductRequest createRequest) => _productService.GetProduct(createRequest);

        [HttpPut("updateProduct")]
        public UpdateProductResponse UpdateProduct(UpdateProductRequest createRequest) => _productService.UpdateProduct(createRequest);

        [HttpDelete("deleteProduct")]
        public DeleteProductResponse deleteProduct(DeleteProductRequest createRequest) => _productService.DeleteProduct(createRequest);
    }
}
