using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
namespace chefs_n_dishes.Models
{
    public class Dish
    {
        [Key]
        public int DishId {get;set;}

        [Required(ErrorMessage="Name of dish is required.")]
        [Display(Name="Name of Dish")]
        public string Name {get;set;}

        [Required(ErrorMessage="Number of calories is required.")]
        [Range(1,int.MaxValue,ErrorMessage="Number of calories must be greater than 0.")]
        [Display(Name="Calories")]
        public int? Calories {get;set;}

        [Required(ErrorMessage="Tastiness is required.")]
        [Display(Name="Tastiness")]
        [Range(1,5,ErrorMessage="Tastiness must be between 1 and 5.")]
        public int Tastiness {get;set;}

        [Required(ErrorMessage="Description is required.")]
        [Display(Name="Description")]
        public string Description {get;set;}

        [Required(ErrorMessage="Chef is required.")]
        [Display(Name="Chef")]
        [Range(1,int.MaxValue,ErrorMessage="You must select a chef.")]
        public int ChefId {get;set;}

        public Chef Creator {get;set;}        
    }
}