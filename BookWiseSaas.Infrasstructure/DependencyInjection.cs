using BookWiseSaas.Application.Common.Interfaces;
using BookWiseSaas.Domain.Entities;
using BookWiseSaas.Domain.Identity;
using BookWiseSaas.Domain.Settings;
using BookWiseSaas.Infrastructure.Persistance.Contexts;
using BookWiseSaas.Infrastructure.Persistence.Contexts;
using BookWiseSaas.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenAI.Extensions;
using Resend;
using System.Data;

namespace BookWiseSaas.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Database Context Configuration
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IApplicationDbContext, ApplicationDbContext>(provider =>
                provider.GetRequiredService<ApplicationDbContext>());

            // Identity Configuration
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

            // Service Configurations
            services.Configure<JwtSettings>(configuration.GetSection(nameof(JwtSettings)));
            services.Configure<GoogleSettings>(configuration.GetSection(nameof(GoogleSettings)));
            services.Configure<IyzicoSettings>(configuration.GetSection(nameof(IyzicoSettings)));

            // Application Services
            services.AddScoped<IJwtService, JwtManager>();
            services.AddScoped<IIdentityService, IdentityManager>();
            services.AddScoped<IEmailService, ResendEmailManager>();
            services.AddScoped<IObjectStorageService, GoogleObjectStorageManager>();
            services.AddScoped<IPaymentService, IyzicoPaymentManager>();

            // OpenAI Service Configuration
            var openAiApiKey = configuration.GetSection("OpenAIApiKey").Value;
            if (string.IsNullOrWhiteSpace(openAiApiKey))
            {
                throw new ArgumentNullException(nameof(openAiApiKey), "OpenAI API Key must be provided.");
            }
            services.AddOpenAIService(settings => settings.ApiKey = openAiApiKey);
            services.AddScoped<IOpenAIService, OpenAIManager>();

            // Resend Service Configuration
            services.AddOptions();
            services.AddHttpClient<ResendClient>();
            services.Configure<ResendClientOptions>(options =>
            {
                var apiToken = configuration.GetSection("ReSendApiKey").Value;
                if (string.IsNullOrWhiteSpace(apiToken))
                {
                    throw new ArgumentNullException(nameof(apiToken), "Resend API Token must be provided.");
                }
                options.ApiToken = apiToken;
            });
            services.AddTransient<IResend, ResendClient>();

            return services;
        }
    }
}
