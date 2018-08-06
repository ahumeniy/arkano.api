namespace arkano.api.Models.Implementations
{
    using arkano.common.configuration;
    using System.Collections.Generic;

    public class TenantsConfiguration
    {
        public List<Tenant> Tenants { get; set; }

        public string Default { get; set; }

        public Tenant Find(string subdomain)
        {
            return this.Tenants.Find(t => t.Subdomain == subdomain) ?? this.Tenants.Find(t => t.Id == this.Default);
        }
    }
}
