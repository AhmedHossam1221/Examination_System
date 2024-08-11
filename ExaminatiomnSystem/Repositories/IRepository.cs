using ExaminatiomnSystem.Models;
using System.Linq.Expressions;

namespace ExaminatiomnSystem.Repositories
{
    public interface IRepository<T> where T : BaseModel
    {
        IQueryable<T> GetAll();
        IQueryable<T> Get(Expression<Func<T, bool>> predicate);
        IQueryable<TResult> Get<TResult>(Expression<Func<T,bool>> predicat,Expression<Func<T,TResult>> selector );
        IQueryable<T> GetByID(int id);
        T GetByIDWithTracing (int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(int id);
        void HardDelete (int id);
        void SaveChanges();
    }
}
