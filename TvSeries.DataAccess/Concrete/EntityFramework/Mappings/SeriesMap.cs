using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TvSeries.Entities.Concrete;

namespace TvSeries.DataAccess.Concrete.EntityFramework.Mappings
{
    public class SeriesMap:IEntityTypeConfiguration<Series>
    {
        public void Configure(EntityTypeBuilder<Series> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).UseIdentityColumn();
            builder.Property(s => s.Name).IsRequired();
            builder.Property(s => s.Name).HasMaxLength(100);
            builder.Property(s => s.Description).IsRequired();
            builder.Property(s => s.Description).HasMaxLength(1000);
            builder.Property(s => s.Genres).IsRequired();
            builder.Property(s => s.Genres).HasMaxLength(100);
            builder.Property(s => s.IsActive).IsRequired();
            builder.ToTable("Series");
            builder.HasData(
                new Series
                {
                    Id = 1,
                    Name = "Friends",
                    Description = "Ross Geller, Rachel Green, Monica Geller, Joey Tribbiani, Chandler Bing, and Phoebe Buffay are six 20 something year olds living in New York City. Over the course of 10 years, these friends go through family, love, drama, friendship, and comedy.",
                    Genres = "Comedy, Romance",
                    IsActive = false
                },
                new Series
                {
                    Id = 2,
                    Name = "How I Met Your Mother",
                    Description = "Ted Mosby sits down with his kids, to tell them the story of how he met their mother. The story is told through memories of his friends Marshall, Lily, Robin, and Barney Stinson. All legendary 9 seasons lead up to the moment of Ted's final encounter with the one.",
                    Genres = "Comedy, Romance",
                    IsActive = false
                },
                new Series
                {
                    Id = 3,
                    Name = "Prison Break",
                    Description = "An innocent man is framed for the homicide of the Vice President's brother and scheduled to be executed at a super-max penitentiary, thus it's up to his younger brother to save him with his genius scheme: install himself in the same prison by holding up a bank and, as the final month ticks away, launch the escape plan step-by-step to break the both of them out, with his full-body tattoo acting as his guide; a tattoo which hides the layout of the prison facility and necessary clues vital to the escape.",
                    Genres = "Action,Crime,Drama,Mystery,Thriller",
                    IsActive = false
                }
            );
        }
    }
}
