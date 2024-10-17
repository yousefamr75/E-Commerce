using DataAcess.IRespositery;
using DataAcess.Migrations;
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
    public class ApplicationUserRespositery : Repositery<ApplicationUser>, IApplicationUserRespositery
        
    {
        private ApplicationDbContext _db;
        public ApplicationUserRespositery(ApplicationDbContext db) : base(db)
        {  _db = db; }

      
    }
}
