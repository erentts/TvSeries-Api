using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TvSeries.DataAccess.Abstract;
using TvSeries.DataAccess.Concrete.EntityFramework;
using TvSeries.DataAccess.Concrete.EntityFramework.Contexts;

namespace TvSeries.DataAccess.Concrete
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly TvSeriesDbContext _tvSeriesDbContext;
        private EfSeriesDal _efSeriesDal;
        private EfActorDal _efActorDal;

        public UnitOfWork(TvSeriesDbContext tvSeriesDbContext)
        {
            _tvSeriesDbContext = tvSeriesDbContext;
        }

        public ISeriesDal Series => _efSeriesDal ?? new EfSeriesDal(_tvSeriesDbContext);
        public IActorDal Actors => _efActorDal ?? new EfActorDal(_tvSeriesDbContext);
        public async Task CommitAsync()
        {
            await _tvSeriesDbContext.SaveChangesAsync();
        }

        public void Commit()
        {
            _tvSeriesDbContext.SaveChanges();
        }
    }
}
