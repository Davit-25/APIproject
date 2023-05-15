using APIproject.Entity;
using APIproject.Interfaces;
using APIproject.Models;
using Microsoft.AspNetCore.Mvc;


namespace APIproject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : Controller
    {
        private readonly ProductManagmentContext _context;
        private readonly ICategoryService _categoryService;


        public CategoryController(ProductManagmentContext context ,ICategoryService categoryService)
        {
            _context = context;
            _categoryService = categoryService;
        }

       

        [HttpPost("createCategory")]
        public CreateCategoryResponse CreateCategory(CreateCategoryRequest createRequest) => _categoryService.CreateCategory(createRequest);


        [HttpGet("getCategory")]
        public GetCategoryResponse GetCategory(GetCategoryRequest getRequest) => _categoryService.GetCategory(getRequest);


        [HttpPut("updateCategory")]
        public UpDateCategoryResponse UpDateCategory(UpDateCategoryRequest updateRequest) => _categoryService.UpDateCategory(updateRequest);

        [HttpDelete("deleteCategory")]
        public DeleteCategoryResponse DeleteCategory(DeleteCategoryRequest deleteCategory)=>_categoryService.DeleteCategory(deleteCategory);
    }
}   
    