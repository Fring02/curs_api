using CURS.Domain.Interfaces.Data;
using CURS.Infrastructure.Data.Config;
using CURS.Infrastructure.Data.Contexts;
using CURS.Infrastructure.Data.Repositories;
using CURS.Infrastructure.Data.Utils;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace CURS.API
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
            services.AddControllers();
            services.Configure<DatabaseSettings>(Configuration.GetSection("MongoSettings"));
            services.AddScoped<MongoContext>();
            services.AddScoped<IUniversitiesRepository, UniversitiesRepository>();
            services.AddScoped<IQSExpertsRepository, QSExpertsRepository>();
            services.AddScoped<IQsExpertFieldsRepository, QsExpertFieldsRepository>();
            services.AddScoped<IProgrammesRepository, ProgrammesRepository>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CURS ArsuDev API", Version = "v1" });
            });
            services.AddAutoMapper(typeof(CURSMapper));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CURS ArsuDev API V1");
            });
        }
    }
}
