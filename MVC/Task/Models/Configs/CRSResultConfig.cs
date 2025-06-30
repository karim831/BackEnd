using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task.Models.Entities;

namespace Task.Models.Configs;

public class CRSResultConfig: IEntityTypeConfiguration<CRSResult>{
    public void Configure(EntityTypeBuilder<CRSResult> builder){
        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.Id).HasColumnType("int").UseIdentityColumn(1,1);
        builder.Property(e => e.Degree).HasColumnType("int").IsRequired();
        builder.Property(e => e.CRSId).HasColumnType("int").IsRequired();
        builder.Property(e => e.TraineeId).HasColumnType("int").IsRequired();
        
        builder.HasOne(e => e.Course).WithMany(e => e.CRSResults).HasForeignKey(e => e.CRSId).OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(e => e.Trainee).WithMany(e => e.CRSResults).HasForeignKey(e => e.TraineeId).OnDelete(DeleteBehavior.NoAction);

        builder.HasData(GetCRSResults());
    }

    CRSResult[] GetCRSResults(){
        return new CRSResult[]{
            new CRSResult { Id = 1, Degree = 85, CRSId = 1, TraineeId = 1 },
            new CRSResult { Id = 2, Degree = 78, CRSId = 2, TraineeId = 1 },
            new CRSResult { Id = 3, Degree = 90, CRSId = 3, TraineeId = 2 },
            new CRSResult { Id = 4, Degree = 65, CRSId = 4, TraineeId = 3 },
            new CRSResult { Id = 5, Degree = 92, CRSId = 5, TraineeId = 4 },
            new CRSResult { Id = 6, Degree = 88, CRSId = 1, TraineeId = 5 },
            new CRSResult { Id = 7, Degree = 74, CRSId = 2, TraineeId = 2 },
            new CRSResult { Id = 8, Degree = 81, CRSId = 3, TraineeId = 3 },
            new CRSResult { Id = 9, Degree = 59, CRSId = 4, TraineeId = 4 },
            new CRSResult { Id = 10, Degree = 95, CRSId = 5, TraineeId = 5 }
        };
    }
}