using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace buyNow.DAL.Interface
{
    public interface IRepository<T> where T : class
    {


        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> where);
        T GetById(object id);
        T GetNonAsync(Expression<Func<T, bool>> where);
        Task<T> Get(Expression<Func<T, bool>> where);
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetMany(Expression<Func<T, bool>> where);
        IEnumerable<T> GetManyNonAsync(Expression<Func<T, bool>> where); 
       
    }
}
