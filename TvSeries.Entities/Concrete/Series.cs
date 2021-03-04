using System;
using System.Collections.Generic;
using System.Text;
using TvSeries.Core.Entities.Abstract;

namespace TvSeries.Entities.Concrete
{
    public class Series:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Genres { get; set; }
        public IList<Actor> Actors { get; set; }
        public bool IsActive  { get; set; }
    }
}
