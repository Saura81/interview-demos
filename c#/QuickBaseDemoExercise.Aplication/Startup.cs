using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using QuickBaseDemoExercise.DataBase;
using QuickBaseDemoExercise.DataBase.Repositories;
using QuickBaseDemoExercise.Domain;
using QuickBaseDemoExercise.Services;
using QuickBaseDemoExercise.Services.Implementations;
using System.Collections;
using System.Collections.Generic;

namespace QuickBaseDemoExercise.Aplication
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
            services.AddScoped<QuickBaseDemoContext>( );
            services.AddDbContext<QuickBaseDemoContext>(options => 
            options.UseSqlite(Configuration.GetConnectionString("QuickBaseDatabase")));
            services.AddScoped<CountryApiService>();
            services.AddScoped<CountryDbService>();
            services.AddScoped<IEqualityComparer<Country>,CountryComparer>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<ICountryIdFactory, CountryIdFactory>(); 

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "QuickBaseDemoExercise.Aplication", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "QuickBaseDemoExercise.Aplication v1"));
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
