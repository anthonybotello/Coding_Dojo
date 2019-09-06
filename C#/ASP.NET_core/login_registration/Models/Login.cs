using System.ComponentModel.DataAnnotations;
namespace login_registration.Models
{
    public class Login
    {
        [Required(ErrorMessage="Email is required!")]
        [EmailAddress(ErrorMessage="Enter a valid email address!")]
        public string LoginEmail {get;set;}

        [Required(ErrorMessage="Password is required!")]
        [DataType(DataType.Password)]
        public string LoginPassword {get;set;}

    }
}