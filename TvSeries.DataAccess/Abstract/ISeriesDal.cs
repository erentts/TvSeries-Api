using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TvSeries.Entities.Concrete;

namespace TvSeries.DataAccess.Abstract
{
    public interface ISeriesDal
    {
        Task<Series> GetWithActorsByIdAsync(int SeriesId);
    }
}
