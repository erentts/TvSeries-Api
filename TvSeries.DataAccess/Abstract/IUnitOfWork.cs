using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TvSeries.DataAccess.Abstract
{
    public interface IUnitOfWork
    {
        ISeriesDal Series { get; }
        IActorDal Actors { get; }
        Task CommitAsync();
        void Commit();
    }
}
