using APIproject.Entity;
using APIproject.Mapping;
using APIproject.Models;

namespace APIproject.Interfaces
{
    public interface IMapper<TEntity,TModel>
    { 
         TModel mapFromEntitytoModel(TEntity source);

         TEntity mapFromModeltoEntityl(TModel source);
        
        void mapFromModeltoEntityl(TModel source,TEntity target);
    }
}
