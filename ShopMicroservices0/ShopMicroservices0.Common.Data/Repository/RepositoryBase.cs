
using System.Linq.Expressions;

namespace ShopMicroservices0.Common.Data.Repository
{
    public interface IRepositoryBase<TEntity, TType> where TEntity : class
    {
        List<TEntity> GetAll();
        TEntity GetEntityByID(TType id);
        void Save(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);

        bool Exists(Expression<Func<TEntity, bool>> filter);
    }
}