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
    public class EfActorDal:EfEntityRepositoryBase<Actor,TvSeriesDbContext>,IActorDal
    {
        private TvSeriesDbContext _TvSeriesDbContext
        {
            get => _context as TvSeriesDbContext;
        }
        public EfActorDal(TvSeriesDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Actor> GetWithSeriesByIdAsync(int ActorId)
        {
            return await _TvSeriesDbContext.Actors.Include(x => x.Series).SingleOrDefaultAsync(x => x.Id == ActorId);
        }
    }
}
