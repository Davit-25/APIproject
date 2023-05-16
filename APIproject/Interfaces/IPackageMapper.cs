using APIproject.Entity;
using APIproject.Mapping;
using APIproject.Models;

namespace APIproject.Interfaces
{
    public interface IPackageMapper<REntity,RModel>
    {
        RModel mapFromEntityToModelPackage(REntity entity);
        REntity mapFromModleToEntityPackage(RModel entity);
        void mapFromModleToEntityPackage(RModel model, REntity entity);
    }
}
