using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

using BookWiseSaas.Infrastructure.Persistance.Contexts;

namespace BookWiseSaas.Infrastructure.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // DbContext yapılandırması
            //services.AddDbContext<ApplicationDbContext>(options =>
                //options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // Diğer altyapı servisleri burada eklenir
            // Örneğin: Redis, caching, logging vb.

            // Konfigürasyonları ekleyin
            // services.AddScoped<IExampleService, ExampleService>();

            return services; // Servis koleksiyonunu döndür
        }
    }
}
