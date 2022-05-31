using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SPVWeb.Models;

namespace SPVWeb.Data
{
    public class ApplicationDbContext :IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Mountain> Mountains { get; set; }
        public DbSet<Rentable> Rentables { get; set; }
    }
}
