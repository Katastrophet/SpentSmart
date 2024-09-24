using Microsoft.EntityFrameworkCore;

namespace SpentSmart.Models

{
    public class SpentSmartDbContext : DbContext
    {
        public DbSet<Expense> Expenses { get; set; }
        public SpentSmartDbContext(DbContextOptions<SpentSmartDbContext> options)
            : base(options)
        {
            
        }
    }
}
