using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MewMart.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required]
        public string Manufacturer { get; set; }
        [Required]
        [Display(Name = "List Pris")]
        [Range(1, 1000)]
        public double ListPrize { get; set; }
        [Required]
        [Display(Name = "Pris")]
        [Range(1, 1000)]
        public double Prize { get; set; }
        [Required]
        [Display(Name = "Pris för 2-4")]
        [Range(1, 1000)]
        public double Prize2 { get; set; }
        [Required]
        [Display(Name = "Pris för 5+")]
        [Range(1, 1000)]
        public double Prize5 { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category Category { get; set; }

        [ValidateNever]
        public string ImageUrl { get; set; }
    }
}
