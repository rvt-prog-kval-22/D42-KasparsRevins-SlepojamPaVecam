using Microsoft.EntityFrameworkCore;
using SPV.Models;

namespace SPV.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}
        public DbSet<Category> Categories { get; set; }
    }
}
