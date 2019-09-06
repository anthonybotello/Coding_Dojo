using System.ComponentModel.DataAnnotations;
namespace quoting_dojo.Models
{
    public class Quote
    {
        [Required(ErrorMessage="You must enter your name!")]
        public string _Name {get;set;}

        [Required(ErrorMessage="You must enter a quote!")]
        public string _Quote {get;set;}
    }
}