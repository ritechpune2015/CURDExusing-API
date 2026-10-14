using Microsoft.EntityFrameworkCore;

namespace CURDEx.Models
{
    public class CompanyContext:DbContext
    {
        public CompanyContext(DbContextOptions<CompanyContext> options) : base(options)
        { }
        public DbSet<Product>   Products { get; set; }
    }
}
