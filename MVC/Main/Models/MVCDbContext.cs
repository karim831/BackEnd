using Main.Models.Config;
using Main.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace Main.Models;
public class MVCDbContext: DbContext{
    public MVCDbContext(DbContextOptions options):base(options){}
    public DbSet<Employee> Employees {get; set;}
    public DbSet<Department> Departments {get; set;}



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EmployeeConfig).Assembly);
    }

}