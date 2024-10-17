using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.IRespositery
{
   public interface IRespositery<T> where T : class 
    {
        IEnumerable<T> GetAll(Expression<Func<T, bool>> ?filter=null ,  string? includeProperties = null);
        T Get(Expression<Func<T, bool>>  filter , string? includeProperties = null , bool tracked = false);
        void add(T entity);
        void remove(T entity);
        void removeRange(IEnumerable<T> entity);



    }

    
}
