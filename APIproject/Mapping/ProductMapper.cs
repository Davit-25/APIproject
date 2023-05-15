using System.Reflection.Metadata.Ecma335;
using APIproject.Entity;
using APIproject.Interfaces;
using APIproject.Models;

namespace APIproject.Mapping
{
    public class ProductMapper: IProductMapper<Product,ProductModel>
    {
        ProductModel IProductMapper<Product, ProductModel>.mapFromEntitytoModelProduct(Product source) => new ProductModel
        {
            ID = source.ID,
            Name = source.Name,
            Description = source.Description,
            price = source.price,
            category = source.category,
        };
        public Entity.Product mapFromModeltoEntitylProdcut(ProductModel source)
        {
            var entity = new Entity.Product();
            mapFromModeltoEntitylProduct(source, entity);
            return entity;
        }
        public void mapFromModeltoEntitylProduct(ProductModel source, Entity.Product entity)
        {
            entity.ID = source.ID;
            entity.Name = source.Name;
            entity.Description = source.Description;
            entity.price = source.price;
            entity.category = source.category;
        }

       
    }
}
