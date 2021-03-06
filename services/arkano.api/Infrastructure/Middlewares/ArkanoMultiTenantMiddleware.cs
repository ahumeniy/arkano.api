﻿namespace arkano.api.Infrastructure.Middlewares
{
    using System.Globalization;
    using System.Threading.Tasks;
    using arkano.api.Models.Implementations;
    using arkano.api.Models.Interfaces;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;

    public class ArkanoMultiTenantMiddleware
    {
        public ArkanoMultiTenantMiddleware(RequestDelegate next, ILogger<ArkanoMultiTenantMiddleware> logger)
        {
            this.Next = next;
            this.Logger = logger;
        }

        private RequestDelegate Next { get; }

        private ILogger<ArkanoMultiTenantMiddleware> Logger { get; }

        private TenantsConfiguration TenantsConfiguration { get; set; }

        public async Task Invoke(HttpContext context, IOptions<TenantsConfiguration> tenantsConfiguration)
        {
            this.TenantsConfiguration = tenantsConfiguration.Value;
            using (this.Logger.BeginScope("TenantResolverMiddleware"))
            {
                string subdomain = this.GetSubdomain(context);
                var tenant = this.TenantsConfiguration.Find(subdomain);
                this.Logger.LogInformation($"Resolved tenant. Current tenant: {tenant.Id}");
                var tenantFeature = new TenantFeature(tenant);
                context.Features.Set<ITenantFeature>(tenantFeature);
                await this.Next(context).ConfigureAwait(true);
            }
        }

        private string GetSubdomain(HttpContext context)
        {
            string subdomain = string.Empty;
            string host = context.Request.Host.Host;
            if (!string.IsNullOrEmpty(host))
            {
                subdomain = host.Split('.')[0];
            }

            return subdomain.Trim().ToLower(new CultureInfo("en"));
        }
    }
}
