using TheplaceEmployeeApp.Data.Entities;
using Microsoft.EntityFrameworkCore;


namespace TheplaceEmployeeApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> contextOptions) : base(contextOptions)
        {

        }

        //using code first Approach
        public DbSet<Employee> Employees { get; set; }
    }
}
