using System.ComponentModel.DataAnnotations;
namespace login_registration.Models
{
    public class IndexViewModel
    {
        public Registration NewRegistration {get;set;}

        public Login UserLogin {get;set;}
        
    }
}