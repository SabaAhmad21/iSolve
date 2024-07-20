using Microsoft.EntityFrameworkCore;

namespace Employee_Entity.DBModels
{
    public class EmployeeManagementContext : DbContext
    {
        public EmployeeManagementContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Gender> Genders { get; set; }
    }
}
