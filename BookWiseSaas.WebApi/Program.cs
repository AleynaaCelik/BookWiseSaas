using BookWiseSaas.Application;  // Application katmanýný kullanmak için gerekli
using BookWiseSaas.Application.Common.Interfaces;  // Common interfaces için gerekli
using BookWiseSaas.Domain.Settings;  // Domain katmanýndaki ayar sýnýflarý için gerekli
using BookWiseSaas.Infrastructure;  // Infrastructure katmanýný kullanmak için gerekli
using BookWiseSaas.WebApi;  // WebApi katmanýndaki sýnýflar için gerekli
using BookWiseSaas.WebApi.Filters;  // WebApi'deki filtreler için gerekli
using BookWiseSaas.WebApi.Hubs;  // SignalR hub'larý için gerekli
using BookWiseSaas.WebApi.Services;  // WebApi servisleri için gerekli
using Microsoft.AspNetCore.Builder;  // ASP.NET Core uygulamasýný yapýlandýrmak için gerekli
using Microsoft.AspNetCore.Mvc;  // MVC ayarlarý için gerekli
using Microsoft.Extensions.Configuration;  // Configuration ayarlarý için gerekli
using Microsoft.Extensions.Options;  // Options pattern için gerekli
using Serilog;  // Serilog için gerekli

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

    builder.Services.AddApplication();  // Application katmaný servislerini ekliyoruz

    builder.Services.AddInfrastructure(builder.Configuration);  // Infrastructure katmaný servislerini ekliyoruz

    builder.Services.AddWebServices(builder.Configuration);  // WebApi katmaný servislerini ekliyoruz

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
