using System.ComponentModel.DataAnnotations;
namespace login_registration.Models
{
    public class Registration
    {
        [Required(ErrorMessage="First name is required!")]
        [MinLength(2,ErrorMessage="First name must be at least 2 characters!")]
        public string FirstName {get;set;}

        [Required(ErrorMessage="Last name is required!")]
        [MinLength(2,ErrorMessage="Last name must be at least 2 characters!")]
        public string LastName {get;set;}

        [Required(ErrorMessage="A valid email is required!")]
        [EmailAddress(ErrorMessage="Enter a valid email address!")]
        public string RegistrationEmail {get;set;}

        [Required(ErrorMessage="Password is required!")]
        [MinLength(8,ErrorMessage="Password must be at least 8 characters!")]
        [DataType(DataType.Password)]
        public string RegistrationPassword {get;set;}

        [Required(ErrorMessage="Password must be confirmed!")]
        [DataType(DataType.Password)]
        [Compare("RegistrationPassword",ErrorMessage="Passwords do not match!")]
        public string ConfirmPassword {get;set;}

    }
}