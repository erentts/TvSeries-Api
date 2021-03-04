using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TvSeries.Entities.Concrete;

namespace TvSeries.DataAccess.Concrete.EntityFramework.Mappings
{
    public class ActorMap:IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).UseIdentityColumn();
            builder.Property(a => a.Name).IsRequired();
            builder.Property(a => a.Name).HasMaxLength(50);
            builder.Property(a => a.Surname).IsRequired();
            builder.Property(a => a.Surname).HasMaxLength(50);
            builder.Property(a => a.SeriesId).IsRequired();
            builder.HasOne<Series>(a => a.Series).WithMany(s => s.Actors).HasForeignKey(a => a.SeriesId);
            builder.ToTable("Actors");
            builder.HasData(
                new Actor
                {
                    Id = 1,
                    SeriesId = 1,
                    Name = "Matt",
                    Surname = "LeBlanc"
                },
                new Actor
                {
                    Id = 2,
                    SeriesId = 1,
                    Name = "Matthew",
                    Surname = "Perry"
                },
                new Actor
                {
                    Id = 3,
                    SeriesId = 1,
                    Name = "Courteney",
                    Surname = "Cox"
                },
                new Actor
                {
                    Id = 4,
                    SeriesId = 2,
                    Name = "Neil Patrick",
                    Surname = "Harris"
                },
                new Actor
                {
                    Id = 5,
                    SeriesId = 3,
                    Name = "Wentworth",
                    Surname = "Miller"
                }

            );
        }
    }
}
