using MasterChef.Application.Interfaces;
using MasterChef.Application.Services;
using MasterChef.Application.Validations;
using MasterChef.Domain.Models;
using MasterChef.Infrastructer.Clients;
using MasterChef.Persistence.Contexts;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MasterChef.IoC
{
    public class DependencyContainer
    {

        public static void RegisterServices(IServiceCollection services)
        {

            services.AddTransient<IValidator<Receita>, ReceitaValidation>();
            services.AddTransient<IValidator<Categoria>, CategoriaValidation>();

            services.AddDataProtection()
               .SetApplicationName("fiap")
               .PersistKeysToFileSystem(new System.IO.DirectoryInfo(@"C:\C#\TrabalhoWeb"));

            services.AddAuthentication("MasterChef")
            .AddCookie("MasterChef", o => {
                o.LoginPath = "/account/index";
                o.AccessDeniedPath = "/account/denied";
            });

            services.AddMemoryCache();
            services.AddControllersWithViews().AddFluentValidation();

            services.AddScoped<IReceitaService, ReceitaService>();
            services.AddScoped<IRssClient, RssGloboClient>();
            services.AddScoped<ILoggerClient, LoggerClient>();

           // var connection = @"Server=(localdb)\NOTE7\Diego;Database=MasterChef2021;Trusted_Connection=True;ConnectRetryCount=0";
            var connection = @"Server=NOTE7;Database=MasterChef2021;User ID=UserMC;Password=123;TrustServerCertificate=True;Trusted_Connection=False;Connection Timeout=30;Integrated Security=False;Persist Security Info=False;Encrypt=True;MultipleActiveResultSets=True;";
            services.AddDbContext<DataContext>(option => option.UseSqlServer(connection));


            services.Configure<GzipCompressionProviderOptions>(o => o.Level = System.IO.Compression.CompressionLevel.Optimal);

            services.AddResponseCompression(o => {

                o.Providers.Add<GzipCompressionProvider>();
                //o.Providers.Add<BrotliCompressionProvider>();
            });
        }
    }
}
