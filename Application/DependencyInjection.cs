using DinkToPdf;
using DinkToPdf.Contracts;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using OfferMakerForCggCQRS.Application.Common.Interfaces;
using OfferMakerForCggCQRS.Application.Common.PipelineBehaviours;
using OfferMakerForCggCQRS.Application.Common.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace OfferMakerForCggCQRS.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddScoped<IPdfConverter, PdfConverter>();

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestLogger<>));
            services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));


            return services;
        }
    }
}
