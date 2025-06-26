using Main.Models.Entity;
using Microsoft.EntityFrameworkCore;

public class MVCDbContext: DbContext{
    public MVCDbContext(DbContextOptions options):base(options){}
    public DbSet<Employee> Employees {get; set;}
    public DbSet<Department> Departments {get; set;}

}