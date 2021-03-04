using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TvSeries.Core.DataAccess.Concrete.EntityFramework;
using TvSeries.DataAccess.Abstract;
using TvSeries.DataAccess.Concrete.EntityFramework.Contexts;
using TvSeries.Entities.Concrete;

namespace TvSeries.DataAccess.Concrete.EntityFramework
{
    public class EfSeriesDal:EfEntityRepositoryBase<Series,TvSeriesDbContext>,ISeriesDal
    {
        private TvSeriesDbContext _TvSeriesDbContext
        {
            get => _context as TvSeriesDbContext;
        }
        public EfSeriesDal(TvSeriesDbContext dbContext) : base(dbContext)
        {
            
        }

        public async Task<Series> GetWithActorsByIdAsync(int SeriesId)
        {
            return await _TvSeriesDbContext.Series.Include(x => x.Actors).SingleOrDefaultAsync(x => x.Id == SeriesId);
        }
    }
}
