using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TvSeries.Core.Entities.Abstract;

namespace TvSeries.Entities.Dtos
{
    public class ActorDto:IDto
    {
        public int Id { get; set; }
        public int SeriesId { get; set; }
        [Required(ErrorMessage = "{0} is require.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "{0} is require.")]
        public string Surname { get; set; }
    }
}
