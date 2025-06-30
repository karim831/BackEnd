using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task.Models.Entities;

namespace Task.Models.Configs;

public class DepartmentConfig: IEntityTypeConfiguration<Department>{
    public void Configure(EntityTypeBuilder<Department> builder){
        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.Id).HasColumnType("int").UseIdentityColumn(1,1);
        builder.Property(e => e.Name).HasColumnType("nvarchar").HasMaxLength(20).IsRequired();
        builder.Property(e => e.ManagerName).HasColumnType("nvarchar").HasMaxLength(20).IsRequired();
        
        
        builder.HasData(GetDepartments());
    }

    Department[] GetDepartments(){
    return new Department[]{
            new Department { Id = 1, Name = "Computer Science", ManagerName = "Dr. Nader" },
            new Department { Id = 2, Name = "Physics", ManagerName = "Dr. Laila" },
            new Department { Id = 3, Name = "Chemistry", ManagerName = "Dr. Amin" },
            new Department { Id = 4, Name = "Mathematics", ManagerName = "Dr. Safaa" },
            new Department { Id = 5, Name = "Networks", ManagerName = "Dr. Tamer" }
        };
    }
}