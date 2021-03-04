using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TvSeries.Business.Services.Abstract;
using TvSeries.Core.DataAccess.Abstract;
using TvSeries.Core.Services.Abstract;
using TvSeries.DataAccess.Abstract;
using TvSeries.Entities.Concrete;

namespace TvSeries.Business.Services.Concrete
{
    public class SeriesManager:ManagerBase<Series>,ISeriesService
    {
        public SeriesManager(IUnitOfWork unitOfWork, IEntityRepository<Series> repository) : base(unitOfWork, repository)
        {
        }

        public async Task<Series> GetWithActorsByIdAsync(int seriesId)
        {
            return await _UnitOfWork.Series.GetWithActorsByIdAsync(seriesId);
        }
    }
}
