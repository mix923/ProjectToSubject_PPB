
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SystemBibloteka.Data;
using SystemBibloteka.Data.EFCore;
using SystemBibloteka.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
//EntityFrameworkCore\Add-Migration AddProductReviews
//Update-Database -Script -SourceMigration:0
namespace SystemBibloteka
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddControllers();
            
            services.AddScoped<libraryRepository>();
            services.AddScoped<BookRepository>();
            services.AddScoped<SchoolRepository>();

            services.AddScoped<ILibraryService, LibraryService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<ISchoolService, SchoolService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Bibloteka uczelniana", Version = "v1" });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description =
        "Autoryzacja. \r\n\r\n Autoryzacja wprowadz token.\r\n\r\nExample: \"Token 12345abcdef\"",
                    Name = "Autoryzacja",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
                });
            });
        }

        
        public void Configure(IApplicationBuilder apps, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()){
                apps.UseDeveloperExceptionPage();
                apps.UseDatabaseErrorPage();}
            else{
                apps.UseExceptionHandler("/ErrorMessage");
                apps.UseHsts();}
            apps.UseHttpsRedirection();
            apps.UseStaticFiles();

            apps.UseRouting();

            apps.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            apps.UseAuthentication();
            apps.UseAuthorization();
            apps.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            apps.UseSwagger();
            apps.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Bibloteka uczelniana wersja 1.0");
                c.RoutePrefix = "";
            });
        }
    }
}
