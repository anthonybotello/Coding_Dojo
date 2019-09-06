using Microsoft.EntityFrameworkCore;

namespace bank_accounts.Models
{
    public class MyContext : DbContext
    {
        public MyContext (DbContextOptions options) : base(options) {}

        public DbSet<User> Users {get;set;}

        public DbSet<Transaction> Transactions {get;set;}
    }
}