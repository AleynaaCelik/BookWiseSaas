using BookWiseSaas.Application;  // Application katman�n� kullanmak i�in gerekli
using BookWiseSaas.Application.Common.Interfaces;  // Common interfaces i�in gerekli
using BookWiseSaas.Domain.Settings;  // Domain katman�ndaki ayar s�n�flar� i�in gerekli
using BookWiseSaas.Infrastructure;  // Infrastructure katman�n� kullanmak i�in gerekli
using BookWiseSaas.WebApi;  // WebApi katman�ndaki s�n�flar i�in gerekli
using BookWiseSaas.WebApi.Filters;  // WebApi'deki filtreler i�in gerekli
using BookWiseSaas.WebApi.Hubs;  // SignalR hub'lar� i�in gerekli
using BookWiseSaas.WebApi.Services;  // WebApi servisleri i�in gerekli
using Microsoft.AspNetCore.Builder;  // ASP.NET Core uygulamas�n� yap�land�rmak i�in gerekli
using Microsoft.AspNetCore.Mvc;  // MVC ayarlar� i�in gerekli
using Microsoft.Extensions.Configuration;  // Configuration ayarlar� i�in gerekli
using Microsoft.Extensions.Options;  // Options pattern i�in gerekli
using Serilog;  // Serilog i�in gerekli

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("/Users/altudev/Desktop/logs.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

try
{
    Log.Information("Starting web application");

    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddSerilog();

    // Add services to the container.
    builder.Services.AddControllers(opt =>
    {
        opt.Filters.Add<GlobalExceptionFilter>();
    });

    builder.Services.AddApplication();  // Application katman� servislerini ekliyoruz

    builder.Services.AddInfrastructure(builder.Configuration);  // Infrastructure katman� servislerini ekliyoruz

    builder.Services.AddWebServices(builder.Configuration);  // WebApi katman� servislerini ekliyoruz

    builder.Services.Configure<ApiBehaviorOptions>(options =>
    {
        options.SuppressModelStateInvalidFilter = true;
    });

    builder.Services.AddSingleton<IRootPathService>(new RootPathManager(builder.Environment.WebRootPath));

    var app = builder.Build();

    app.UseCors("AllowAll");

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseStaticFiles();

    var requestLocalizationOptions = app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>();

    app.UseRequestLocalization(requestLocalizationOptions.Value);

    app.UseHttpsRedirection();

    app.UseAuthentication();

    app.UseAuthorization();

    app.MapControllers();

   // app.MapHub<OrderHub>("/hubs/orderHub");

    app.Run();

}
catch (Exception e)
{
    Log.Fatal(e, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}
