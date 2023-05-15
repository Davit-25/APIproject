using APIproject.Entity;
using APIproject.Mapping;
using APIproject.Models;

namespace APIproject.Interfaces
{
    public interface IProductMapper<PEntity, PModel>
    {
        PModel mapFromEntitytoModelProduct(PEntity model);
        PEntity mapFromModeltoEntitylProdcut(PModel entity);
        void mapFromModeltoEntitylProduct(PModel model, PEntity entity);

    }
}
