using DataAcess.IRespositery;
using E_Commerce.Data;
using E_Commerce.Models;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Repositery
{
    public class CompanyRespositery : Repositery<Company>, ICompanyRespositery

    {
        private ApplicationDbContext _db;
        public CompanyRespositery(ApplicationDbContext db) : base(db)
        {  _db = db; }
          

    

        

        public void Update(Company obj)
        {
           _db.companies.Update(obj);
        }

      
    }
}
