using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task.Models.Entities;

namespace Task.Models.Configs;

public class CourseConfig: IEntityTypeConfiguration<Course>{
    public void Configure(EntityTypeBuilder<Course> builder){
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id).HasColumnType("int").UseIdentityColumn(1,1);
        builder.Property(e => e.Name).HasColumnType("nvarchar").HasMaxLength(20).IsRequired();
        builder.Property(e => e.MaxDegree).HasColumnType("int").IsRequired();
        builder.Property(e => e.MinDegree).HasColumnType("int").IsRequired();
        builder.Property(e => e.Hours).HasColumnType("int").IsRequired();
        builder.Property(e => e.DeptId).HasColumnType("int").IsRequired();

        builder.HasOne(e => e.Department).WithMany(e => e.Courses).HasForeignKey(e => e.DeptId).OnDelete(DeleteBehavior.NoAction);

        builder.HasData(GetCourses());
    }

    Course[] GetCourses(){
        return new Course[]{
            new Course { Id = 1, Name = "Math", MaxDegree = 100, MinDegree = 50, Hours = 3, DeptId = 1 },
            new Course { Id = 2, Name = "Physics", MaxDegree = 100, MinDegree = 45, Hours = 4, DeptId = 1 },
            new Course { Id = 3, Name = "Chemistry", MaxDegree = 100, MinDegree = 50, Hours = 3, DeptId = 2 },
            new Course { Id = 4, Name = "Programming", MaxDegree = 100, MinDegree = 60, Hours = 5, DeptId = 3 },
            new Course { Id = 5, Name = "Networks", MaxDegree = 100, MinDegree = 50, Hours = 4, DeptId = 3 },
        };
    }
}