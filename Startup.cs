using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using OfferMakerForCggCQRS.Persistence;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using FluentValidation;
using OfferMakerForCggCQRS.Application.Common.PipelineBehaviours;
using FluentValidation.AspNetCore;
using OfferMakerForCggCQRS.Application.Common.Models;
using OfferMakerForCggCQRS.Application.Common.Models.Pagination;
using OfferMakerForCggCQRS.Infrastructure.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using OfferMakerForCggCQRS.Application.Common.Interfaces;
using System.Security.Claims;
using DinkToPdf.Contracts;
using DinkToPdf;
using OfferMakerForCggCQRS.Application.Common.Services;
using OfferMakerForCggCQRS.Application;
using OfferMakerForCggCQRS.Infrastructure;

namespace OfferMakerForCggCQRS
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("frontClient", builder => {
                    builder.WithOrigins("http://localhost:4200")
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowCredentials();
                });
            });


            //services.AddScoped<IUserContextService, UserContextService>();
            services.AddHttpContextAccessor();
            services.AddInfrastructure(Configuration, Environment);
            services.AddPersistence(Configuration);

            //services.AddDbContext<OffermakerDbContext>(options =>
            //    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
            //    b => b.MigrationsAssembly(typeof(OffermakerDbContext).Assembly.FullName)));

            services.AddSwaggerGen(c =>
            {
                c.IncludeXmlComments(string.Format(@"{0}\CQRS.WebApi.xml", System.AppDomain.CurrentDomain.BaseDirectory));
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "CQRS.WebApi",
                });

            });
            //services.AddScoped<IOffermakerDbContext>(provider => provider.GetService<OffermakerDbContext>());

            services.AddApplication();

            services.AddControllers().AddFluentValidation();

            services.AddValidatorsFromAssembly(typeof(Startup).Assembly);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("frontClient");
            app.UseAuthentication();

            app.UseHttpsRedirection();
            

            app.UseRouting();
            

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CQRS.WebApi");
            });
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
