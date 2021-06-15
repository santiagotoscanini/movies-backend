using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reflection;
using Microsoft.OpenApi.Models;
using Infrastructure.Data;
using Infrastructure.Data.Repositories;
using InfrastructureInterface.Data.Repositories;
using ApplicationCore.Services;
using ApplicationCoreInterface.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Factory
{
    [ExcludeFromCodeCoverage]
    public class ServiceFactory
    {
        private readonly IServiceCollection _services;

        public ServiceFactory(IServiceCollection services)
        {
            _services = services;
        }

        public void AddCustomServices()
        {
            _services.AddScoped<IMovieRepository, MovieRepository>();

            _services.AddScoped<IMovieService, MovieService>();
        }

        public void AddDbContextService()
        {
            _services.AddDbContext<DbContext, MoviesContext>();
        }
        
        public void AddSwagger(String xmlFilePath)
        {
            _services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Movies Swagger",
                    Description = "Swagger documentation for Movies API",
                    
                });
                c.IncludeXmlComments(xmlFilePath);
            });
            
            _services.AddSwaggerGenNewtonsoftSupport();
        }
    }
}
