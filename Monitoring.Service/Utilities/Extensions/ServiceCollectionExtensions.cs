using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using AutoMapper;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Monitoring.Service.Entities.ModelMaps.AutoMapper;
using Monitoring.Service.Utilities.Settings;

namespace Monitoring.Service.Utilities.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection GetAutoMapperConfiguration(this IServiceCollection services)
        {
            return services.AddSingleton(CreateAutoMapperConfiguration());
        }

        private static IMapper CreateAutoMapperConfiguration()
        {
            return (new MapperConfiguration(configure => { configure.AddProfile(new MappingProfile()); }))
                .CreateMapper();
        }

        public static IServiceCollection CorsConfiguration(this IServiceCollection services)
        {
            return services.AddCors(opts =>
            {
                opts.AddDefaultPolicy(builder => { builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod(); });
            });
        }

        public static IServiceCollection MongoDbConfiguration(this IServiceCollection services,
            IConfiguration configuration)
        {
            return services.Configure<MongoSettings>(options =>
            {
                options.ConnectionString = configuration.GetConnectionString("MongoConnectionString");
                options.DefaultDatabase = configuration.GetConnectionString("DefaultDatabase");
            });
        }

        public static IServiceCollection SwaggerConfiguration(this IServiceCollection services)
        {
            return services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo {Title = "Monitoring API", Version = "v1"});

                x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the bearer scheme",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });
                x.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Id = "Bearer",
                                Type = ReferenceType.SecurityScheme
                            }
                        },
                        new List<string>()
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                x.IncludeXmlComments(xmlPath);
            });
        }

        public static IServiceCollection AppMetricsConfiguration(this IServiceCollection services)
        {
           return services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            }).AddMetrics();
        }
    }
}