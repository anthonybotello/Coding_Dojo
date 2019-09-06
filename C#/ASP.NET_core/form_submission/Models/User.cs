using System.ComponentModel.DataAnnotations;
using System;
namespace form_submission.Models
{
    public class User
    {
        [Required(ErrorMessage="First name is required!")]
        [MinLength(4,ErrorMessage="First name must be at least 4 characters!")]
        [Display(Name="First Name:")]
        public string FirstName {get;set;}
    
        [Required(ErrorMessage="Last name is required!")]
        [MinLength(4,ErrorMessage="Last name must be at least 4 characters!")]
        [Display(Name="Last Name:")]
        public string LastName {get;set;}

        [Required(ErrorMessage="Age is required!")]
        [Display(Name="Age:")]
        [Range(1,200,ErrorMessage="Age must be greater than 0!")]
        public int Age {get;set;}

        [Required(ErrorMessage="Birthday is required!")]
        [Display(Name="Birthday:")]
        [DataType(DataType.Date)]
        [PastDate(ErrorMessage="Birthday cannot be in the future!")]
        public DateTime Birthday {get;set;}

        [Required(ErrorMessage="A valid email is required!")]
        [EmailAddress]
        [Display(Name="Email:")]
        public string Email {get;set;}

        [Required(ErrorMessage="Password is required!")]
        [DataType(DataType.Password)]
        [MinLength(8,ErrorMessage="Password must be at least 4 characters!")]
        [Display(Name="Password")]
        public string Password {get;set;}

    }

    public class PastDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (DateTime.Compare((DateTime)value,DateTime.Now) > 0)
            {
                return new ValidationResult("Birthday cannot be in the future!");
            }
            return ValidationResult.Success;
        }
    }
}