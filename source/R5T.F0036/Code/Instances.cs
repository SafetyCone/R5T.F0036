using System;


namespace R5T.F0036
{
    public static class Instances
    {
        public static F000.IHasServicesOperator HasServicesOperator => F000.HasServicesOperator.Instance;
        public static F000.IServiceCollectionBuilderOperator ServiceCollectionBuilderOperator => F000.ServiceCollectionBuilderOperator.Instance;
        public static F000.IServiceCollectionOperator ServiceCollectionOperator => F000.ServiceCollectionOperator.Instance;
        public static IServicesBuilderOperator ServicesBuilderOperator => F0036.ServicesBuilderOperator.Instance;
        public static F001.IServicesConfigurerOperator ServicesConfigurerOperator => F001.ServicesConfigurerOperator.Instance;
        public static F000.IServiceProviderBuilderOperator ServiceProviderBuilderOperator => F000.ServiceProviderBuilderOperator.Instance;
        public static F000.IServiceProviderOperator ServiceProviderOperator => F000.ServiceProviderOperator.Instance;

        public static F000.IServiceProviderOperator ServiceProvider => F000.Instances.ServiceProvider;
        public static F000.IServiceCollectionOperator Services => F000.Instances.Services;
    }
}