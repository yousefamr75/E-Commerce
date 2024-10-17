 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.IRespositery
{
    public interface IUniteOfWork
    {
        ICategoryRespositery Category { get; }
        IProductRespositery product { get; }
        ICompanyRespositery Company { get; }
       
        IApplicationUserRespositery ApplicationUser { get; }

        void save();
    }
}
