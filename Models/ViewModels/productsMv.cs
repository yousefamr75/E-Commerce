using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Models.Models.ViewModels
{
    public class productsMv
    {
        public products products{ get; set; }
        [ValidateNever]
        public  IEnumerable<SelectListItem> CategoryList { get; set; }
    }
}
