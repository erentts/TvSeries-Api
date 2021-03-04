using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TvSeries.Business.Services.Abstract;
using TvSeries.Core.DataAccess.Abstract;
using TvSeries.DataAccess.Abstract;
using TvSeries.Entities.Concrete;

namespace TvSeries.Business.Services.Concrete
{
    public class ActorManager:ManagerBase<Actor>,IActorService
    {
        public ActorManager(IUnitOfWork unitOfWork, IEntityRepository<Actor> repository) : base(unitOfWork, repository)
        {
        }

        public async Task<Actor> GetWithSeriesByIdAsync(int actorId)
        {
            return await _UnitOfWork.Actors.GetWithSeriesByIdAsync(actorId);
        }
    }
}
