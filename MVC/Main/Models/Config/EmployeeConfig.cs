using Main.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Main.Models.Config;

public class EmployeeConfig: IEntityTypeConfiguration<Employee>{
    public void Configure(EntityTypeBuilder<Employee> builder){
        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.Id).HasColumnName("Id").HasColumnType("int").UseIdentityColumn(1,1);
        builder.Property(e => e.Name).HasColumnType("nvarchar").HasMaxLength(20).IsRequired();
        builder.Property(e => e.Salary).HasColumnType("int").IsRequired();
        builder.Property(e => e.JobTitle).HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
        builder.Property(e => e.ImageUrl).HasColumnType("varchar").IsRequired(false);
        builder.Property(e => e.Address).HasColumnType("nvarchar").HasMaxLength(20).IsRequired(false);
        builder.Property(e => e.DepartmentId).HasColumnType("int").IsRequired();

        builder.HasOne(e => e.Department).WithMany(e => e.Employees).HasForeignKey(e => e.DepartmentId).OnDelete(DeleteBehavior.NoAction);

        builder.HasData(GetData());
    }

    private Employee[] GetData(){
        var employees = new List<Employee>{
            new Employee {Id = 1,Name = "Ali Mahmoud", Salary = 6000, JobTitle = "Software Engineer", ImageUrl = null, Address = "Cairo", DepartmentId = 1 },
            new Employee {Id = 2,Name = "Sara Ahmed", Salary = 7500, JobTitle = "QA Engineer", ImageUrl = null, Address = "Alexandria", DepartmentId = 2 },
            new Employee {Id = 3,Name = "Mohamed Nabil", Salary = 8000, JobTitle = "Project Manager", ImageUrl = null, Address = "Cairo", DepartmentId = 1 },
            new Employee {Id = 4,Name = "Yasmin Fathy", Salary = 5500, JobTitle = "UI/UX Designer", ImageUrl = null, Address = "Giza", DepartmentId = 3 },
            new Employee {Id = 5,Name = "Omar Khaled", Salary = 9000, JobTitle = "DevOps Engineer", ImageUrl = null, Address = "6th October", DepartmentId = 2 },
            new Employee {Id = 6,Name = "Mona Samir", Salary = 6700, JobTitle = "Database Administrator", ImageUrl = null, Address = "Mansoura", DepartmentId = 3 },
            new Employee {Id = 7,Name = "Khaled Hussein", Salary = 6200, JobTitle = "Backend Developer", ImageUrl = null, Address = "Cairo", DepartmentId = 1 },
            new Employee {Id = 8,Name = "Laila Gamal", Salary = 5800, JobTitle = "Frontend Developer", ImageUrl = null, Address = "Helwan", DepartmentId = 1 },
            new Employee {Id = 9,Name = "Tamer Ali", Salary = 7200, JobTitle = "System Analyst", ImageUrl = null, Address = "Zagazig", DepartmentId = 2 },
            new Employee {Id = 10,Name = "Nour Hassan", Salary = 6300, JobTitle = "Support Engineer", ImageUrl = null, Address = "Fayoum", DepartmentId = 3 }
        };

        return employees.ToArray();
    }
} 