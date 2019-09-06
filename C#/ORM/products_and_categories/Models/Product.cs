using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
namespace products_and_categories.Models
{
    public class Product
    {
        [Key]
        public int ProductId {get;set;}

        [Required(ErrorMessage="Product name is required.")]
        public string Name {get;set;}

        [Required(ErrorMessage="Product description is required.")]
        public string Description {get;set;}

        [Required(ErrorMessage="Product price is required.")]
        public decimal? Price {get;set;}

        public DateTime CreatedAt {get;set;} = DateTime.Now;

        public DateTime UpdatedAt {get;set;} = DateTime.Now;

        public List<Association> Categories {get;set;}

    }
}