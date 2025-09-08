using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using rep_pattern_demo.Models;


namespace RepositoryWithMVC.Models
{
    public class EmployeeContext : DbContext
    {
      public EmployeeContext(DbContextOptions<EmployeeContext> options)
    : base(options){}
       public DbSet<Employee> Employees
        {
            get;
            set;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.Entity<Employee>().ToTable("Employees");
             base.OnModelCreating(modelBuilder);
        }

    }


}