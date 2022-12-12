using ServerAPI.Contracts;
using ServerAPI.LoggerService;

namespace ServerAPI.Extensions
{
    public static class ServiceExtensions
    {

// cors configuration
public static void ConfigureCors(this IServiceCollection services)
{
      services.AddCors(options =>
      {
          options.AddPolicy("CorsPolicy",
              builder => builder.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());
      });
}


//IIS Configuration
public static void ConfigureIISIntegration(this IServiceCollection services)
{
      services.Configure<IISOptions>(options => 
      {
      });          
}

//
public static void ConfigureLoggerService(this IServiceCollection services)
{
    services.AddSingleton<ILoggerManager, LoggerManager>();
}

    }
}