using Microsoft.EntityFrameworkCore;
using ServiceCenterWebApp.API.Models;

namespace ServiceCenterWebApp.API.Data
{
    public class ServiceCenterDbContext:DbContext
    {
        public ServiceCenterDbContext( DbContextOptions option):base(option)
        { }

        public DbSet<Employee> Employees { get; set; }


    }
}
