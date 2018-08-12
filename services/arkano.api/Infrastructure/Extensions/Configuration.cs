namespace arkano.api.Infrastructure.Extensions
{
    using System.IO;
    using arkano.api.Infrastructure.Middlewares;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.Configuration;

    public static class Configuration
    {
        public static string BasePath => $@"{Directory.GetCurrentDirectory()}/Configuration";

        public static IConfiguration LoadTenantConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(BasePath)
                .AddJsonFile("tenants.json", false, true);
            return builder.Build();
        }

        public static IApplicationBuilder UseMultiTenantMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ArkanoMultiTenantMiddleware>();
        }

        public static IApplicationBuilder UseArkanoLoggerMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ArkanoLoggerMiddleware>();
        }
    }
}
