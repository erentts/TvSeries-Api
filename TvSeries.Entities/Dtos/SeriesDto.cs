using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TvSeries.Core.Entities.Abstract;

namespace TvSeries.Entities.Dtos
{
    public class SeriesDto:IDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Genres { get; set; }
    }
}
