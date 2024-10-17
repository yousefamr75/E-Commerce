using E_Commerce.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Models.Models
{
    public class products
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string title { get; set; }
        public string description { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        [Display(Name = "List Prise")]
        [Range(1, 100000)]
        public double ListPrise { get; set; }

        [Required]
        [Display(Name = " Prise For 1-50")]
        [Range(1, 100000)]
        public double Prise { get; set; }
        [Required]
        [Display(Name = " Prise For 50+")]
        [Range(1, 100000)]
        public double Prise50 { get; set; }
        [Required]
        [Display(Name = " Prise For 100+")]
        [Range(1, 100000)]
        public double Prise100 { get; set; }

       public int CategoryId { get; set; }
       
        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category Category { get; set; }
        [ValidateNever]
        public string ImageUrl { get; set; }


    
      
        


    }
}
