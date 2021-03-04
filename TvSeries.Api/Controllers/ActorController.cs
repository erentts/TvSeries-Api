using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TvSeries.Api.Filters;
using TvSeries.Business.Services.Abstract;
using TvSeries.Entities.Concrete;
using TvSeries.Entities.Dtos;

namespace TvSeries.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly IActorService _actorService;
        private readonly IMapper _mapper;

        public ActorController(IActorService actorService, IMapper mapper)
        {
            _actorService = actorService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var actors = await _actorService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<ActorDto>>(actors));
        }

        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var actor = await _actorService.GetByIdAsync(id);
            return Ok(_mapper.Map<ActorDto>(actor));
        }

        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpGet("{id}/series")]
        public async Task<IActionResult> GetWithSeriesById(int id)
        {
            var actor = await _actorService.GetWithSeriesByIdAsync(id);
            return Ok(_mapper.Map<ActorWithSeriesDto>(actor));
        }
        
        [ValidationFilter]
        [HttpPost]
        public async Task<IActionResult> Save(ActorDto actorDto)
        {
            var newActor = await _actorService.AddAsync(_mapper.Map<Actor>(actorDto));
            return Created(string.Empty, _mapper.Map<ActorDto>(newActor));
        }

        [HttpPut]
        public IActionResult Update(ActorDto actorDto)
        {
            var updateActor = _actorService.Update(_mapper.Map<Actor>(actorDto));
            return NoContent();
        }

        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var deletedActor = _actorService.GetByIdAsync(id).Result;
            _actorService.Remove(deletedActor);
            return NoContent();
        }
    }
}
