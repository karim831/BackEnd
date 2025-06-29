using Main.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Main.Models.Config;
public class DepartmentConfig: IEntityTypeConfiguration<Department>{
    public void Configure(EntityTypeBuilder<Department> builder){
        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.Id).HasColumnName("Id").HasColumnType("int").UseIdentityColumn(1,1);
        builder.Property(e => e.Name).HasColumnType("nvarchar").HasMaxLength(20).IsRequired();
        builder.Property(e => e.ManagerName).HasColumnType("nvarchar").HasMaxLength(20).IsRequired(false);

        builder.HasData(GetData());
    }

    private Department[] GetData(){
        var departments = new List<Department>
        {
            new Department {Id = 1,Name = "Software Development", ManagerName = "Dr. Tarek Mostafa" },
            new Department {Id = 2,Name = "Quality Assurance", ManagerName = "Eng. Amal Fahmy" },
            new Department {Id = 3,Name = "IT Operations", ManagerName = "Mr. Hesham Magdy" }
        };

        return departments.ToArray();
    }
}