using DataAcess.IRespositery;
using E_Commerce.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Repositery
{
    public class Uniteofwork : IUniteOfWork
    {
        private ApplicationDbContext _db;
        public ICategoryRespositery Category { get; private set; }
        public IProductRespositery product { get; private set; }
        public ICompanyRespositery Company { get; private set; }
public IApplicationUserRespositery ApplicationUser { get; private set; }
        public Uniteofwork(ApplicationDbContext db)
        { 
         _db = db;
           
        Category=new CategoryRespositery(_db);
       product=new ProductRespositery(_db);
       Company=new CompanyRespositery(_db);
       ApplicationUser=new ApplicationUserRespositery(db);



        }
       

        public void save()
        {
            _db.SaveChanges();
        }
    }

    
}
