using System;
using System.Collections.Generic;
using System.Text;
using TvSeries.Core.Entities.Abstract;

namespace TvSeries.Entities.Dtos
{
    public class SeriesWithActorsDto:SeriesDto,IDto
    {
        public IEnumerable<ActorDto> Actors { get; set; }
    }
}
