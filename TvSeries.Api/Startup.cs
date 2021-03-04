using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TvSeries.Api.Filters;
using TvSeries.Business.Services.Abstract;
using TvSeries.Business.Services.Concrete;
using TvSeries.Core.DataAccess.Abstract;
using TvSeries.Core.DataAccess.Concrete.EntityFramework;
using TvSeries.Core.Services.Abstract;
using TvSeries.DataAccess.Abstract;
using TvSeries.DataAccess.Concrete;
using TvSeries.DataAccess.Concrete.EntityFramework;
using TvSeries.DataAccess.Concrete.EntityFramework.Contexts;
using TvSeries.Entities.Concrete;

namespace TvSeries.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<NotFoundFilter>();
            services.AddScoped(typeof(IEntityRepository<Actor>), typeof(EfEntityRepositoryBase<Actor,TvSeriesDbContext>));
            services.AddScoped(typeof(IEntityRepository<Series>), typeof(EfEntityRepositoryBase<Series, TvSeriesDbContext>));
            services.AddScoped(typeof(IService<>), typeof(ManagerBase<>));
            services.AddScoped<IActorService, ActorManager>();
            services.AddScoped<ISeriesService, SeriesManager>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddDbContext<TvSeriesDbContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionStrings:SqlConStr"].ToString(), o =>
                {
                    o.MigrationsAssembly("TvSeries.DataAccess");
                });
            });
            

            services.AddControllers();

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TvSeries.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TvSeries.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
