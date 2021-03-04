using System;
using System.Collections.Generic;
using System.Text;
using TvSeries.Core.Entities.Abstract;

namespace TvSeries.Entities.Concrete
{
    public class Actor:IEntity
    {
        public int Id { get; set; }
        public int SeriesId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public virtual Series Series { get; set; }
    }
}
