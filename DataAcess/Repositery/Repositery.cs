using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAcess.IRespositery;
using DataAcess.Repositery;
using E_Commerce.Data;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DataAcess.Repositery
{
    public class Repositery<T> : IRespositery<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        public DbSet<T> Set;

        public Repositery( ApplicationDbContext db )
        {
           _db = db;
            this.Set = _db.Set<T>();
            _db.products.Include(u => u.Category).Include(u=>u.CategoryId);

        }
        public void add(T entity)
        {
           Set.Add( entity );    
        }

        public T Get(Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked = false)
        {
            IQueryable<T> query;
            if (tracked)
            {

                query = Set;
  

            }
            else
            {
                query = Set.AsNoTracking();
               

            }
            query = query.Where(filter);
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeprop in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeprop);
                }


            }
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>?
            filter, string? includeProperties=null)
        {
            IQueryable<T> query = Set;
            if (filter != null)
            {
                query = query.Where(filter);
            }


            if (!string.IsNullOrEmpty(includeProperties ))
            {
                foreach(var includeprop in includeProperties.Split(new char[] { ','}, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeprop);

                }


            }
            return query.ToList();
        }

        public void remove(T entity)
        {
        Set.Remove( entity );

        }

        public void removeRange(IEnumerable<T> entity)
        {
            Set.RemoveRange( entity );
        }
    }
}
