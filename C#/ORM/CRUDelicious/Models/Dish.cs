using System.ComponentModel.DataAnnotations;
using System;
namespace CRUDelicious.Models
{
    public class Dish
    {
        [Key]
        public int id {get;set;}

        [Required(ErrorMessage="Name of dish is required.")]
        public string Name {get;set;}

        [Required(ErrorMessage="Name of chef is required.")]
        public string Chef {get;set;}

        [Required]
        [Range(1,5,ErrorMessage="Tastiness is required.")]
        public int Tastiness {get;set;}

        [Required(ErrorMessage="Calories is required.")]
        [Range(1,int.MaxValue,ErrorMessage="Calories must be greater than 0.")]
        public int? Calories {get;set;}

        [Required(ErrorMessage="Description is required.")]
        public string Description {get;set;}

        public DateTime created_at {get;set;} = DateTime.Now;
        public DateTime updated_at {get;set;} = DateTime.Now;  
    }
}