using System.Reflection.Metadata.Ecma335;
using APIproject.Entity;
using APIproject.Interfaces;
using APIproject.Models;

namespace APIproject.Mapping
{
    public class CategoryMapper : IMapper<Entity.Category, CreateCategoryModel>
    {
        CreateCategoryModel IMapper<Category, CreateCategoryModel>.mapFromEntitytoModel(Category source) => new CreateCategoryModel
        {
            Name = source.Name,
            Code = source.Code,
            Description = source.Description,
            ID = source.ID,
        };
      
        public Entity.Category mapFromModeltoEntityl(CreateCategoryModel source)
        {
            var entity = new Entity.Category();

            mapFromModeltoEntityl(source, entity);
            return entity;
        }
        public void mapFromModeltoEntityl(CreateCategoryModel source, Entity.Category entity)
        {
            entity.Name = source.Name;
            entity.Code = source.Code;
            entity.Description = source.Description;
            entity.ID = source.ID;
        }

    }
}
