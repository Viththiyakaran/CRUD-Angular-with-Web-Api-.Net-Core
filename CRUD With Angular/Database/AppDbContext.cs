using CRUD_With_Angular.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_With_Angular.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) 
        { 
        
        }

        public DbSet<Employee> tblEmployee { get; set; }    
       
    }
}
