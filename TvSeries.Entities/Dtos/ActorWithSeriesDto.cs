using System;
using System.Collections.Generic;
using System.Text;
using TvSeries.Core.Entities.Abstract;
using TvSeries.Entities.Concrete;

namespace TvSeries.Entities.Dtos
{
    public class ActorWithSeriesDto:ActorDto,IDto
    {
        public SeriesDto Series { get; set; }
    }
}
