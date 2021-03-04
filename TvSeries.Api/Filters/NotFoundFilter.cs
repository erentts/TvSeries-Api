using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TvSeries.Business.Services.Abstract;
using TvSeries.Entities.Dtos;

namespace TvSeries.Api.Filters
{
    public class NotFoundFilter:ActionFilterAttribute
    {
        private readonly IActorService _actorService;
        public NotFoundFilter(IActorService actorService)
        {
            _actorService = actorService;
        }

        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            int id = (int) context.ActionArguments.Values.FirstOrDefault();
            var product = await _actorService.GetByIdAsync(id);
            if (product != null)
            {
                await next();
            }
            else
            {
                ErrorDto errorDto = new ErrorDto();
                errorDto.Status = 404;
                errorDto.Errors.Add($"id : {id} is not found.");
                context.Result = new NotFoundObjectResult(errorDto);
            }
        }
    }
}
