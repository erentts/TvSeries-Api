using System;
using System.Collections.Generic;
using System.Text;

namespace TvSeries.Entities.Dtos
{
    public class ErrorDto
    {
        public ErrorDto()
        {
            Errors = new List<string>();
        }
        public List<String> Errors { get; set; }
        public int Status { get; set; }
    }
}
