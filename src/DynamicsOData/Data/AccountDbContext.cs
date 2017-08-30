using DynamicsOData.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DynamicsOData.Data
{
    public class AccountDbContext : IdentityDbContext<ApplicationUser>
    {
        public AccountDbContext(DbContextOptions<AccountDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
