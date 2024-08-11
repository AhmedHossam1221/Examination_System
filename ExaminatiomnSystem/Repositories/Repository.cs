using ExaminatiomnSystem.Data;
using ExaminatiomnSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ExaminatiomnSystem.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseModel
    {
        private readonly Context _context;
        public Repository(Context context )
        {
            _context=context;
        }
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            entity.IsDeleted = true;
            Update(entity);
        }

        public void Delete(int id)
        {
            T entity = _context.Find<T>(id);
            Delete(entity);
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return GetAll().Where(predicate);
        }

        public IQueryable<TResult> Get<TResult>(Expression<Func<T, bool>> predicat, System.Linq.Expressions.Expression<Func<T, TResult>> selector)
        {
            return GetAll().Where(predicat).Select(selector);
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>().Where(x=>!x.IsDeleted);
        }

        public IQueryable<T> GetByID(int id)
        {
            return _context.Set<T>().Where(x=>x.ID == id&& !x.IsDeleted);
        }

        public T GetByIDWithTracing(int id)
        {
           return GetByID(id).AsTracking().FirstOrDefault();
        }

        public void HardDelete(int id)
        {
            _context.Set<T>().Where(x=>x.ID == id).ExecuteDelete();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
