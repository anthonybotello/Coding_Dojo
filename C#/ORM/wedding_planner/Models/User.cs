using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System;
namespace wedding_planner.Models
{
    public class User
    {
        [Key]
        public int UserId {get;set;}

        [Required(ErrorMessage="First name is required.")]
        [MinLength(2,ErrorMessage="First name must be at least 2 characters.")]
        public string FirstName {get;set;}

        [Required(ErrorMessage="Last name is required.")]
        [MinLength(2,ErrorMessage="Last name must be at least 2 characters.")]
        public string LastName {get;set;}

        [Required(ErrorMessage="Email address is required.")]
        [EmailAddress(ErrorMessage="Enter a valid email address.")]
        public string Email {get;set;}

        [Required(ErrorMessage="Password is required.")]
        [MinLength(8,ErrorMessage="Password must be at least 8 characters long.")]
        [DataType(DataType.Password)]
        public string Password {get;set;}

        [NotMapped]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage="Passwords do not match.")]
        public string Confirm {get;set;}
        
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;

        public List<RSVP> Weddings {get;set;}
    }
}