namespace arkano.common.configuration
{
    public class ArkanoContext
    {
        public ArkanoContext(Tenant tenant)
        {
            this.Tenant = tenant;
        }

        public Tenant Tenant { get; }
    }
}
