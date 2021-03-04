using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TvSeries.Entities.Concrete;
using TvSeries.Entities.Dtos;

namespace TvSeries.Api.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Series, SeriesDto>();
            CreateMap<SeriesDto, Series>();

            CreateMap<Series, SeriesWithActorsDto>();
            CreateMap<SeriesWithActorsDto, Series>();

            CreateMap<Actor, ActorDto>();
            CreateMap<ActorDto, Actor>();

            CreateMap<Actor, ActorWithSeriesDto>();
            CreateMap<ActorWithSeriesDto, Actor>();
        }
    }
}
