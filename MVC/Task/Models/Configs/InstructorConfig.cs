using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task.Models.Entities;

namespace Task.Models.Configs;

public class InstructorConfig: IEntityTypeConfiguration<Instructor>{
    public void Configure(EntityTypeBuilder<Instructor> builder){
        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.Id).HasColumnType("int").UseIdentityColumn(1,1);
        builder.Property(e => e.Name).HasColumnType("nvarchar").HasMaxLength(20).IsRequired();
        builder.Property(e => e.Image).HasColumnType("nvarchar").HasMaxLength(20).IsRequired(false);
        builder.Property(e => e.Address).HasColumnType("nvarchar").HasMaxLength(20).IsRequired(false);
        builder.Property(e => e.Salary).HasColumnType("int").IsRequired();
        builder.Property(e => e.DeptId).HasColumnType("int").IsRequired();
        builder.Property(e => e.CRSId).HasColumnType("int").IsRequired(false);
        
        builder.HasOne(e => e.Department).WithMany(e => e.Instructors).HasForeignKey(e => e.DeptId).OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(e => e.Course).WithMany(e => e.Instructors).HasForeignKey(e => e.CRSId).OnDelete(DeleteBehavior.NoAction);   
        
        builder.HasData(GetInstructors());
    }
    Instructor[] GetInstructors(){
        return new Instructor[]{
            new Instructor { Id = 1, Name = "Ahmed Samir", Image = "ahmed.png", Address = "Cairo", Salary = 15000, DeptId = 1, CRSId = 1 },
            new Instructor { Id = 2, Name = "Sara Hany", Image = "sara.png", Address = "Giza", Salary = 14000, DeptId = 1, CRSId = 2 },
            new Instructor { Id = 3, Name = "Tamer Youssef", Image = null, Address = "Alex", Salary = 16000, DeptId = 2, CRSId = 3 },
            new Instructor { Id = 4, Name = "Nourhan Taha", Image = "nourhan.png", Address = "Mansoura", Salary = 14500, DeptId = 3, CRSId = 4 },
            new Instructor { Id = 5, Name = "Hossam Reda", Image = null, Address = null, Salary = 13000, DeptId = 5, CRSId = null }
        };
    }
}