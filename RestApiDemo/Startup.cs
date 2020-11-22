using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using RestApiDemo.Data;
using RestApiDemo.Data.Repository;
using RestApiDemo.Services;
using RestApiDemo.Settings;

namespace RestApiDemo
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
            services.AddDbContext<SqlDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("SqlDbConnection")));


            //Swagger config with versioning
            services.AddVersionedApiExplorer(c =>
            {
                c.GroupNameFormat = "'v'VV";
            });

            var apiVersion = new ApiVersionSettings();
            Configuration.GetSection(nameof(ApiVersionSettings)).Bind(apiVersion);

            services.AddApiVersioning(c =>
            {
                c.AssumeDefaultVersionWhenUnspecified = true;
                c.DefaultApiVersion = new ApiVersion(apiVersion.Version, 0);
                c.ReportApiVersions = true;
                c.ApiVersionReader = new UrlSegmentApiVersionReader();

            });

            var apiVersionDescriptionProvider = services.BuildServiceProvider().GetService<IApiVersionDescriptionProvider>();

            services.AddSwaggerGen(c =>
            {
                foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
                {
                    c.SwaggerDoc($"ProductsOpenApiSpecification{description.GroupName}",
                        new OpenApiInfo
                        {
                            Title = "Products API",
                            Version = description.ApiVersion.ToString(),
                            Description = $"Demo API to access products (actually running on Api version set to: v{apiVersion.Version}.0)",
                            Contact = new OpenApiContact()
                            {
                                Email = "marek.styblo@gmail.com",
                                Name = "Marek Stýblo"
                            }
                        });
                    var xmlCommentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                    var xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentsFile);

                    c.IncludeXmlComments(xmlCommentsFullPath);
                };

                c.DocInclusionPredicate((documentName, apiDescription) =>
                {
                    var actionApiVersionModel = apiDescription.ActionDescriptor
                    .GetApiVersionModel(ApiVersionMapping.Explicit | ApiVersionMapping.Implicit);

                    if (actionApiVersionModel == null)
                    {
                        return true;
                    }

                    if (actionApiVersionModel.DeclaredApiVersions.Any())
                    {
                        return actionApiVersionModel.DeclaredApiVersions.Any(v =>
                        $"ProductsOpenApiSpecificationv{v.ToString()}" == documentName);
                    }
                    return actionApiVersionModel.ImplementedApiVersions.Any(v =>
                        $"ProductsOpenApiSpecificationv{v.ToString()}" == documentName);
                });
            });


            services.AddAutoMapper(typeof(AutoMapperProfileProduct));

            services.AddControllers();

            services.AddSingleton<ILoggingService, LoggingService>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider apiVersionDescriptionProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
                {
                    c.SwaggerEndpoint($"/swagger/ProductsOpenApiSpecification{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                }
            });


            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
