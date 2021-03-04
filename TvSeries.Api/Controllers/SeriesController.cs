using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TvSeries.Business.Services.Abstract;
using TvSeries.Entities.Concrete;
using TvSeries.Entities.Dtos;

namespace TvSeries.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeriesController : ControllerBase
    {
        private readonly ISeriesService _seriesService;
        private readonly IMapper _mapper;

        public SeriesController(ISeriesService seriesService, IMapper mapper)
        {
            _seriesService = seriesService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var series = await _seriesService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<SeriesDto>>(series));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var series = await _seriesService.GetByIdAsync(id);
            return Ok(_mapper.Map<SeriesDto>(series));
        }

        [HttpGet("{id}/actors")]
        public async Task<IActionResult> GetWithActorsById(int id)
        {
            var series = await _seriesService.GetWithActorsByIdAsync(id);
            return Ok(_mapper.Map<SeriesWithActorsDto>(series));
        }

        [HttpPost]
        public async Task<IActionResult> Save(SeriesDto seriesDto)
        {
            var newSeries = await _seriesService.AddAsync(_mapper.Map<Series>(seriesDto));
            return Created(string.Empty, _mapper.Map<SeriesDto>(newSeries));
        }

        [HttpPut]
        public IActionResult Update(SeriesDto seriesDto)
        {
            var series = _seriesService.Update(_mapper.Map<Series>(seriesDto));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var deletedSeries = _seriesService.GetByIdAsync(id).Result;
            _seriesService.Remove(deletedSeries);
            return NoContent();
        }

    }
}
