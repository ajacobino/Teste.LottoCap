using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Teste.LottoCap
{
    /// <summary>
    /// Classe de start da api  
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Método de inicializacao da classe
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Propriedade de retorno das configuracoes
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Método de configuracao
        /// </summary>
        /// <param name="services">Servicos a serem utilizados</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            //configuracao do swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = GetType().Assembly.GetName().Name,
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Name = "Alexandre Arruda Jacobino",
                        Email = "ajacobino@gmail.com"
                    },
                    Description = "Interface de Teste da api via swagger",
                    Version = GetType().Assembly.GetName().Version.ToString()


                });

                string xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.XML";
                string xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                
                //inclui a documentação gerada 
                c.IncludeXmlComments(xmlPath); ;
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();


            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", GetType().Assembly.GetName().Name);
            });
            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseCors();

        }
    }
}
