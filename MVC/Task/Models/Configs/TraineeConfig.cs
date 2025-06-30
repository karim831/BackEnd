using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task.Models.Entities;

namespace Task.Models.Configs;

public class TraineeConfig: IEntityTypeConfiguration<Trainee>{
    public void Configure(EntityTypeBuilder<Trainee> builder){
        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.Id).HasColumnType("int").UseIdentityColumn(1,1);
        builder.Property(e => e.Name).HasColumnType("nvarchar").HasMaxLength(20).IsRequired();
        builder.Property(e => e.Image).HasColumnType("nvarchar").HasMaxLength(20).IsRequired(false);
        builder.Property(e => e.Address).HasColumnType("nvarchar").HasMaxLength(20).IsRequired(false);
        builder.Property(e => e.Grade).HasColumnType("int").IsRequired();
        builder.Property(e => e.DeptId).HasColumnType("int").IsRequired();
        
        builder.HasOne(e => e.Department).WithMany(e => e.Trainees).HasForeignKey(e => e.DeptId).OnDelete(DeleteBehavior.NoAction);

        builder.HasData(GetTrainees());
    }

    Trainee[] GetTrainees(){
        return new Trainee[]{
            new Trainee { Id = 1, Name = "Ali Hassan", Image = "ali.png", Address = "Cairo", Grade = 85, DeptId = 1 },
            new Trainee { Id = 2, Name = "Mona Gamal", Image = "mona.png", Address = "Giza", Grade = 92, DeptId = 1 },
            new Trainee { Id = 3, Name = "Ibrahim Said", Image = null, Address = "Alex", Grade = 78, DeptId = 2 },
            new Trainee { Id = 4, Name = "Reem Adel", Image = "reem.jpg", Address = "Mansoura", Grade = 88, DeptId = 3 },
            new Trainee { Id = 5, Name = "Tarek Helmy", Image = null, Address = null, Grade = 73, DeptId = 3 }
        };
    }


}