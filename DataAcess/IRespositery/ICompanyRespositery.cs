using E_Commerce.Models;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.IRespositery
{
    public interface ICompanyRespositery : IRespositery<Company>
    {
        void Update(Company obj);
        

    }
}
