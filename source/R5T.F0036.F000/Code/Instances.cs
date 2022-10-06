using System;


namespace R5T.F0036.F000
{
    public static class Instances
    {
        public static IHasServicesOperator HasServicesOperator { get; } = F000.HasServicesOperator.Instance;
        public static IServiceCollectionBuilderOperator ServiceCollectionBuilderOperator { get; } = F000.ServiceCollectionBuilderOperator.Instance;
        public static IServiceCollectionOperator ServiceCollectionOperator { get; } = F000.ServiceCollectionOperator.Instance;
        public static IServiceProviderBuilderOperator ServiceProviderBuilderOperator { get; } = F000.ServiceProviderBuilderOperator.Instance;
        public static IServiceProviderOperator ServiceProviderOperator { get; } = F000.ServiceProviderOperator.Instance;
        public static IServicesBuilderOperator ServicesBuilderOperator { get; } = F000.ServicesBuilderOperator.Instance;

        public static IServiceProviderOperator ServiceProvider => Instances.ServiceProviderOperator;
        public static IServiceCollectionOperator Services => Instances.ServiceCollectionOperator;
    }
}