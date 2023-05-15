using APIproject.Interfaces;
using APIproject.Models;
using Microsoft.EntityFrameworkCore;
using APIproject.Mapping;
using APIproject.Entity;

namespace APIproject.Services
{
    public class CategoryService
    {//მეთოდის შიგთავსი
        private readonly ProductManagmentContext _context;
        private readonly IMapper<Entity.Category, CreateCategoryModel> _categoryMapper;

        public CategoryService( ProductManagmentContext context)
        {
            _categoryMapper = new CategoryMapper();
            _context = context;
        }

        public CreateCategoryResponse CreateCategory(CreateCategoryModel category)
        {
            var CategoryAlreadytExists = _context.Categories.Any(p => p.ID == category.ID);
            if (CategoryAlreadytExists)
            {
              throw new DbUpdateException($"categoy with ID{category.ID} already exist");

            }
            var categoryEntity = _categoryMapper.mapFromModeltoEntityl(category);
            var newCategory = _context.Categories.Add(categoryEntity);

            _context.SaveChanges();
            return new CreateCategoryResponse { createCategoryModel = category };
        }

        public GetCategoryResponse GetCategory(GetCategoryRequest getCategoryRequest)
        {
            var category = _context.Categories.Find( getCategoryRequest.ID);

            return new GetCategoryResponse { getCategoryModel = _categoryMapper.mapFromEntitytoModel(category) };
        }

        public UpDateCategoryResponse UpDateCategory(UpDateCategoryRequest upDateCategoryRequest)
        {
            var existingCategoryToUpdate = _context.Categories.Find(upDateCategoryRequest.categoryToUpdate.ID);

            if (existingCategoryToUpdate==null)
            {
                throw new DbUpdateException("There is no such ID");
            }

            _categoryMapper.mapFromModeltoEntityl(upDateCategoryRequest.categoryToUpdate, existingCategoryToUpdate);

            _context.SaveChanges();
            return new UpDateCategoryResponse { updateCategory = upDateCategoryRequest.categoryToUpdate };
        }

        public DeleteCategoryResponse DeleteCategory(DeleteCategoryRequest deleteCategoryRequest)
        {
            var categoryToDelete = _context.Categories.Find( deleteCategoryRequest.ID);
            if (categoryToDelete==null)
            {
                throw new DbUpdateException($"category with ID{deleteCategoryRequest.ID} does not exist");
            }
            _context.Categories.Remove( categoryToDelete );
            _context.SaveChanges();
            return new DeleteCategoryResponse();
        }
    }
}
