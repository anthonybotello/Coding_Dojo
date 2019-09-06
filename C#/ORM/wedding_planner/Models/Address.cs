using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
namespace wedding_planner.Models
{
    public class Address
    {
        [Key]
        public int AddressId {get;set;}

        [Required(ErrorMessage="Street Address is required.")]
        public string StreetAddress {get;set;}

        [Required(ErrorMessage="City is required.")]
        public string City {get;set;}

        [Required(ErrorMessage="State is required.")]
        [MinLength(2,ErrorMessage="Enter state abbreviation, e.g. TX, WA, CA...")]
        [MaxLength(2,ErrorMessage="Enter state abbreviation, e.g. TX, WA, CA...")]
        public string State {get;set;}

        [Required(ErrorMessage="Five digit zip code is required.")]
        [Range(0,99999,ErrorMessage="Zip code must be five digits.")]
        public int? ZipCode {get;set;}

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;

        public int WeddingId {get;set;}

    }
}