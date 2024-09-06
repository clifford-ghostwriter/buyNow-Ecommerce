using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using buyNow.DAL.Interface;
using buyNow_Ecommerce.Data;
using Microsoft.EntityFrameworkCore;

namespace buyNow.DAL.Implementation
{
    public class Repository<T> : IRepository<T> where T : class
    {


        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;

       public Repository(ApplicationDbContext db)
        {
            _db = db;
            dbSet = _db.Set<T>();
        }

        public void Add(T entity)
        {if (entity == null) return;
            dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Expression<Func<T, bool>> where)
        {

            IEnumerable<T> objects = dbSet.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
                dbSet.Remove(obj);
        }

        public async Task<T> Get(Expression<Func<T, bool>> where)
        {
            if (where != null)
                return await dbSet.Where(where).FirstOrDefaultAsync();
            else
                return await dbSet.SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {

            return await dbSet.ToListAsync();
        }

        public T GetById(object id)
        {
            return dbSet.Find(id);
        }

        public async Task<IEnumerable<T>> GetMany(Expression<Func<T, bool>> where)
        {
            return await dbSet.Where(where).ToListAsync();
        }

        public IEnumerable<T> GetManyNonAsync(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where).ToList();
        }

        public T GetNonAsync(Expression<Func<T, bool>> where)
        {
            if (where != null)
                return dbSet.Where(where).FirstOrDefault<T>();
            else
                return dbSet.SingleOrDefault();
        }

        public void Update(T entity)
        {
            dbSet.Attach(entity);
            dbSet.Entry(entity).State = EntityState.Modified;
        }

  


    }
}
