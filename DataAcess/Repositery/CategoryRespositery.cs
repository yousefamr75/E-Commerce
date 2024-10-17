using DataAcess.IRespositery;
using E_Commerce.Data;
using E_Commerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Repositery
{
    public class CategoryRespositery : Repositery<Category>, ICategoryRespositery
        
    {
        private ApplicationDbContext _db;
        public CategoryRespositery(ApplicationDbContext db) : base(db)
        {  _db = db; }
          

    

        

        public void Update(Category obj)
        {
           _db.categories.Update(obj);
        }

      
    }
}
