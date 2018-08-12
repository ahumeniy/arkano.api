namespace arkano.api.Models.Interfaces
{
    using arkano.common.configuration;

    public interface ITenantFeature
    {
        Tenant Tenant { get; set; }
    }
}
