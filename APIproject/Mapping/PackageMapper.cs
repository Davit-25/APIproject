using System.Reflection.Metadata.Ecma335;
using APIproject.Entity;
using APIproject.Interfaces;
using APIproject.Models;

namespace APIproject.Mapping
{
    public class PackageMapper: IPackageMapper<Package, PackageModel>
    {
        PackageModel IPackageMapper<Package, PackageModel>.mapFromEntityToModelPackage(Package model) => new PackageModel
        {
            ID = model.ID,
            Name = model.Name,
            Description = model.Description,
            price = model.price,
            PackageProduct = model.PackageProduct,
        };

        public Package mapFromModleToEntityPackage(PackageModel packageModel)
        {
            var entity = new Entity.Package();
            mapFromModleToEntityPackage(packageModel, entity);
            return entity;
        }

        public void mapFromModleToEntityPackage(PackageModel packageModel,Package entity)
        {
            entity.ID = packageModel.ID;
            entity.Name = packageModel.Name;
            entity.Description = packageModel.Description;
            entity.price = packageModel.price;
            entity.PackageProduct = packageModel.PackageProduct;
        }
    }
 
}
