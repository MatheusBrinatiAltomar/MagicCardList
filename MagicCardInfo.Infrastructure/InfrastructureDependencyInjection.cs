using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MagicCardInfo.Domain.Repositories;
using MagicCardInfo.Infrastructure.Models;
using MagicCardInfo.Infrastructure.Persistance;

namespace MagicCardInfo.Infrastructure
{
    public static class InfrastructureDependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<ICardRepository, CardRepositry>();

            return services;
        }
    }
}
