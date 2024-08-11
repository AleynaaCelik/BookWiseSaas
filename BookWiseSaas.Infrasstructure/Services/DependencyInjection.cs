using BookWiseSaas.Domain.Entities;
using BookWiseSaas.Domain.Settings;
using BookWiseSaas.Infrastructure.Persistance.Contexts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWiseSaas.Infrastructure.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IApplicationDbContext, ApplicationDbContext>(
                container => container.GetRequiredService<ApplicationDbContext>());

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.Configure<JwtSettings>(jwtSettings => configuration.GetSection("JwtSettings").Bind(jwtSettings));
            services.Configure<GoogleSettings>(googleSettings => configuration.GetSection("GoogleSettings").Bind(googleSettings));
            services.Configure<IyzicoSettings>(iyzicoSettings => configuration.GetSection("IyzicoSettings").Bind(iyzicoSettings));

            services.AddIdentity<User, Role>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;

                options.User.RequireUniqueEmail = true;

            })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // // Sets the token lifespan to three hours for the email confirmation token
            // services.Configure<DataProtectionTokenProviderOptions>(options =>
            // {
            //     options.TokenLifespan = TimeSpan.FromHours(3); // Sets the expiry to three hours
            // });

            services.AddScoped<IJwtService, JwtManager>();
            services.AddScoped<IIdentityService, IdentityManager>();
            services.AddScoped<IEmailService, ResendEmailManager>();
            services.AddScoped<IObjectStorageService, GoogleObjectStorageManager>();
            services.AddScoped<IPaymentService, IyzicoPaymentManager>();

            //OpenAI
            services.AddOpenAIService(settings =>
                settings.ApiKey = configuration.GetSection("OpenAIApiKey").Value!);

            services.AddScoped<IOpenAIService, OpenAIManager>();

            // Resend
            services.AddOptions();
            services.AddHttpClient<ResendClient>();
            services.Configure<ResendClientOptions>(o =>
            {
                o.ApiToken = configuration.GetSection("ReSendApiKey").Value!;
            });
            services.AddTransient<IResend, ResendClient>();


            return services;
        }
    }
}
