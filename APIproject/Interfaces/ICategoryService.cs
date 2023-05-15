using APIproject.Models;

namespace APIproject.Interfaces
{
    public interface ICategoryService
    {//მეთოდის აღწერა
        CreateCategoryResponse CreateCategory(CreateCategoryRequest category);
        GetCategoryResponse GetCategory(GetCategoryRequest category);
        UpDateCategoryResponse UpDateCategory(UpDateCategoryRequest category);
        DeleteCategoryResponse DeleteCategory(DeleteCategoryRequest category);
    }
}
