using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TvSeries.DataAccess.Concrete.EntityFramework.Mappings;
using TvSeries.Entities.Concrete;

namespace TvSeries.DataAccess.Concrete.EntityFramework.Contexts
{
    public class TvSeriesDbContext:DbContext
    {
        public TvSeriesDbContext(DbContextOptions<TvSeriesDbContext> options) : base(options)
        {
        }

        public DbSet<Series> Series { get; set; }
        public DbSet<Actor> Actors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ActorMap());
            modelBuilder.ApplyConfiguration(new SeriesMap());
        }
    }
}
