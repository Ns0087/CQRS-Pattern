using Microsoft.EntityFrameworkCore;
using CQRS_Pattern.DAL.Entities;

namespace CQRS_Pattern.DAL.DBContext
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
