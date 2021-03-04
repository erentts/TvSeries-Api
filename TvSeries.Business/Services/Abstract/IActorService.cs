using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TvSeries.Core.Services;
using TvSeries.Core.Services.Abstract;
using TvSeries.Entities.Concrete;

namespace TvSeries.Business.Services.Abstract
{
    public interface IActorService:IService<Actor>
    {
        Task<Actor> GetWithSeriesByIdAsync(int actorId);
    }
}
