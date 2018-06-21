﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Examples;
using Swashbuckle.AspNetCore.Swagger;
using System;

namespace Livraria.Api
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
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "API de Pagamento",
                    Description = "Um exemplo de endpoints de uma API mock de pagamento construída com ASP.NET Core Web API",
                    Contact = new Contact
                    {
                        Name = "Otávio Augusto de Queiroz Reis",
                        Email = "otavioreis@gmail.com",
                        Url = String.Empty
                    },
                    License = new License
                    {
                        Name = "Licença MIT",
                        Url = "https://raw.githubusercontent.com/otavioreis/ArquiteturaBackEndApiPagamento/master/LICENSE"
                    }
                });
                c.IncludeXmlComments(GetXmlCommentsPath());
                c.OperationFilter<ExamplesOperationFilter>(); // [SwaggerRequestExample] & [SwaggerResponseExample]
                c.OperationFilter<DescriptionOperationFilter>(); // [Description] on Response properties
            });

            services.AddMvc();
        }

        protected static string GetXmlCommentsPath()
        {
            return System.String.Format(@"{0}\Swagger.xml", System.AppDomain.CurrentDomain.BaseDirectory);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pagamento API V1");
            });

            app.UseMvc();
        }


    }
}
