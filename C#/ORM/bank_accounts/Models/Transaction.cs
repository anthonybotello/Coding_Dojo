using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
namespace bank_accounts.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId {get;set;}

        [Required(ErrorMessage="Enter an amount.")]
        [Display(Name="Deposit/Withdraw: ")]
        [NotZero]
        public double? Amount {get;set;}

        public DateTime created_at {get;set;} = DateTime.Now;

        public int UserId {get;set;}
    }

    public class NotZeroAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if ((double?)value == (double?)0)
            {
                return new ValidationResult("Transaction amount cannot be 0.");
            }
            return ValidationResult.Success;
        }
    }
}