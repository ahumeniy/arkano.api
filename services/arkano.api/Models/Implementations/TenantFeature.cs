namespace arkano.api.Models.Implementations
{
    using arkano.api.Models.Interfaces;
    using arkano.common.configuration;

    public class TenantFeature : ITenantFeature
    {
        public TenantFeature(Tenant tenant)
        {
            this.Tenant = tenant;
        }

        public Tenant Tenant { get; set; }
    }
}
