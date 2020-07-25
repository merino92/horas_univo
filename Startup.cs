using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using univo.Controllers;
using univo.custom;
using univo.data;

namespace univo
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
            string cadena1 = Configuration.GetConnectionString("casa");
            string cadena2 = Configuration.GetConnectionString("trabajo");
            services.AddDbContext<univoContext>(
              options => options.UseSqlServer(cadena1));
            services.AddDataProtection()
            .UseCryptographicAlgorithms(new AuthenticatedEncryptorConfiguration{
               
              ValidationAlgorithm = ValidationAlgorithm.HMACSHA256
            }); //algoritmos validos para la encriptacion
                
            services.AddControllersWithViews();
            services.AddScoped<Rolesrepository,Rolesrepository>();
            services.AddScoped<ModulosRepository,ModulosRepository>();
            services.AddScoped<encrypt,encrypt>();
            services.AddScoped<UsuarioRepository,UsuarioRepository>();
            services.AddMvc().AddControllersAsServices();
            services.AddSession();
            //services.AddScoped<, Hello>();
            
             
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
           

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

            });
        }
    }
}
