using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
namespace wedding_planner.Models
{
    public class Wedding
    {
        [Key]
        public int WeddingId {get;set;}

        [Required(ErrorMessage="Wedder One is required.")]
        public string WedderOne {get;set;}

        [Required(ErrorMessage="Wedder Two is required.")]
        public string WedderTwo {get;set;}

        [Required(ErrorMessage="Wedding date is required.")]
        [DataType(DataType.Date)]
        [FutureDate]
        public DateTime? Date {get;set;}

        public int AddressId {get;set;}

        public int CreatorId {get;set;}

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;

        [NotMapped]
        public Address WeddingAddress {get;set;}

        public List<RSVP> Guests {get;set;}
    }

    public class FutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                if (DateTime.Compare(((DateTime)value).Date, DateTime.Now.Date) <= 0)
                {
                    return new ValidationResult("Wedding date must be in the future.");
                }
                return ValidationResult.Success;
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}