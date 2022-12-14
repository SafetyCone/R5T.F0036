using System;

using R5T.F0036.F000;
using R5T.F0036.F001;


namespace R5T.F0036
{
    public static class Instances
    {
        public static IHasServicesOperator HasServicesOperator { get; } = F000.HasServicesOperator.Instance;
        public static IServiceCollectionBuilderOperator ServiceCollectionBuilderOperator { get; } = F000.ServiceCollectionBuilderOperator.Instance;
        public static IServiceCollectionOperator ServiceCollectionOperator { get; } = F000.ServiceCollectionOperator.Instance;
        public static IServicesBuilderOperator ServicesBuilderOperator { get; } = F0036.ServicesBuilderOperator.Instance;
        public static IServicesConfigurerOperator ServicesConfigurerOperator { get; } = F001.ServicesConfigurerOperator.Instance;
        public static IServiceProviderBuilderOperator ServiceProviderBuilderOperator { get; } = F000.ServiceProviderBuilderOperator.Instance;
        public static IServiceProviderOperator ServiceProviderOperator { get; } = F000.ServiceProviderOperator.Instance;

        public static IServiceProviderOperator ServiceProvider => F000.Instances.ServiceProvider;
        public static IServiceCollectionOperator Services => F000.Instances.Services;
    }
}