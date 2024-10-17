using E_Commerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.IRespositery
{
    public interface ICategoryRespositery : IRespositery<Category>
    {
        void Update(Category obj);
        

    }
}
