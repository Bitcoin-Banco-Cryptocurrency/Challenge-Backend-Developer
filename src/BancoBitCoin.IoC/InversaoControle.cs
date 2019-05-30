using BancoBitCoin.Application.Interfaces;
using BancoBitCoin.Application.Service;
using BancoBitCoin.Domain.Application;
using BancoBitCoin.Domain.Interfaces.Application;
using BancoBitCoin.Domain.Repository;
using BancoBitCoin.Infra.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace BancoBitCoin.IoC
{
    public class InversaoControle
    {

        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IBookAppService, BookAppService>();
            services.AddScoped<IBookService, BookService>();
        }     

    }
}
