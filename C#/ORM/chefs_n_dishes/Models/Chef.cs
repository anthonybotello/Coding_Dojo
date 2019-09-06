using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System;
namespace chefs_n_dishes.Models
{
    public class Chef
    {
        [Key]
        public int ChefId {get;set;}

        [Required(ErrorMessage="Chef's first name is required.")]
        [Display(Name="First Name")]
        public string FirstName {get;set;}

        [Required(ErrorMessage="Chef's last name is required.")]
        public string LastName {get;set;}

        [Required(ErrorMessage="Chef's birthday is required.")]
        [PastDate]
        [Adult]
        [Display(Name="Birthday")]
        [DataType(DataType.Date)]
        public DateTime Birthday {get;set;}

        public List<Dish> CreatedDishes {get;set;} = new List<Dish>();

        [NotMapped]
        public int Age {
            get{
                return (int)((DateTime.Now.Date - (DateTime)Birthday.Date).Days/365.25);
            }}

        [NotMapped]
        public int NumberOfDishes {
            get
            {
                return CreatedDishes.Count;
            }}
    }

    public class PastDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (DateTime.Compare((DateTime)value,DateTime.Now) > 0)
            {
                return new ValidationResult("Birthday must be a past date.");
            }
            return ValidationResult.Success;
        }
    }

    public class AdultAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid (object value, ValidationContext validationContext)
        {
            TimeSpan daysOld = DateTime.Now.Date - ((DateTime)value).Date;
            int yearsOld = (int)(daysOld.Days/365.25);            
            if (yearsOld < 18)
            {
                return new ValidationResult("Chefs must be 18 years or older.");
            }
            return ValidationResult.Success;
        }
    }    
}