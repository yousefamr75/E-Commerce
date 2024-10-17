 using DataAcess.IRespositery;
using E_Commerce.Data;
using E_Commerce.Models;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Repositery
{
    public class ProductRespositery : Repositery<products>, IProductRespositery

    {
        private ApplicationDbContext _db;
        public ProductRespositery(ApplicationDbContext db) : base(db)
        { _db = db; }






        public void Update(products obj)
        {
            var objFromDb = _db.products.FirstOrDefault(u => u.Id == obj.Id); 
            
                if (objFromDb != null)
                {
                    objFromDb.ISBN = obj.ISBN;
                    objFromDb.title = obj.title;
                    objFromDb.Prise = obj.Prise;
                    objFromDb.Prise50 = obj.Prise50;
                    objFromDb.ListPrise = obj.ListPrise;
                    objFromDb.Prise100 = obj.Prise100;
                    objFromDb.description = obj.description;
                    objFromDb.CategoryId = obj.CategoryId;
                    objFromDb.Author = obj.Author;

                    if (obj.ImageUrl != null)
                    {
                        objFromDb.ImageUrl = obj.ImageUrl;
                    }
                }
            }
        }
    }

                        
        

      
    

