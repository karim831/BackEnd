using Microsoft.EntityFrameworkCore;
using Task.Models.Configs;
using Task.Models.Entities;

namespace Task.Models;

public class TaskDbContext: DbContext{
    public TaskDbContext(DbContextOptions options):base(options){}

    public DbSet<Course> Courses {get; set;}
    public DbSet<CRSResult> CRSResults {get; set;}
    public DbSet<Trainee> Trainees {get; set;}
    public DbSet<Department> Departments {get;set;}
    public DbSet<Instructor> Instructors {get;set;}
    protected override void OnModelCreating(ModelBuilder modelBuilder){
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CourseConfig).Assembly);
    }
}