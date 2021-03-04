using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TvSeries.Entities.Concrete;

namespace TvSeries.DataAccess.Abstract
{
    public interface IActorDal
    {
        Task<Actor> GetWithSeriesByIdAsync(int ActorId);   
    }
}
