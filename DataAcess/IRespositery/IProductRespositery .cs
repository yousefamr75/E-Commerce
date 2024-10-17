 using E_Commerce.Models;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.IRespositery
{
    public interface IProductRespositery : IRespositery<products>
    {
        void Update(products obj);
        

    }
}
