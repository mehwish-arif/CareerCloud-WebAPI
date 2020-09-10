using System;
using CareerCloud.DataAccessLayer;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using CareerCloud.Pocos;
using Microsoft.Extensions.Logging;

namespace CareerCloud.EntityFrameworkDataAccess
{
    public class EFGenericRepository<T> : IDataRepository<T> where T: class
    {
        private CareerCloudContext _context;
       

        public EFGenericRepository()
        {
           // DbContextOptions<CareerCloudContext> options = new DbContextOptions<CareerCloudContext>();
            _context = new CareerCloudContext();
        }
        
        
        public void Add(params T[] items)
        {
            foreach (T record in items)
            {
                _context.Entry(record).State = EntityState.Added;
                _context.SaveChanges();
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

      public IList<T> GetAll(params System.Linq.Expressions.Expression<Func<T, object>>[] navigationProperties)
        {

            IQueryable<T> dbQuery = _context.Set<T>();
            foreach (var navProp in navigationProperties)
            {
                dbQuery = dbQuery.Include<T, object>(navProp);

            }

            return dbQuery.ToList();
        }

        public IList<T> GetList(System.Linq.Expressions.Expression<Func<T, bool>> where, params System.Linq.Expressions.Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> dbQuery = _context.Set<T>();
            foreach (var navProp in navigationProperties)
            {
                dbQuery = dbQuery.Include<T, object>(navProp);

            }

            return dbQuery.Where(where).ToList();

        }

        public T GetSingle(System.Linq.Expressions.Expression<Func<T, bool>> where, params System.Linq.Expressions.Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> dbQuery = _context.Set<T>();

            foreach (Expression<Func<T, object>> navProp in navigationProperties)
            {
                dbQuery = dbQuery.Include<T, object>(navProp);
            }

           // return dbQuery.ToList();
            return dbQuery.FirstOrDefault(where);

        }

       public void Remove(params T[] items)
        {
            foreach (T record in items)
            {
                _context.Entry(record).State = EntityState.Deleted;
                _context.SaveChanges();
            }
        }

        public void Update(params T[] items)
        {
            foreach (T record in items)
            {
                _context.Entry(record).State = EntityState.Modified;
                try
                {
                    _context.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
