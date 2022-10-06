using System;

using R5T.F0036.F000;


namespace R5T.F0036.F001
{
    public static class Instances
    {
        public static IServiceCollectionBuilderOperator ServiceCollectionBuilderOperator { get; } = F000.ServiceCollectionBuilderOperator.Instance;
        public static IServicesConfigurerOperator ServicesConfigurerOperator { get; } = F001.ServicesConfigurerOperator.Instance;
        public static IServiceProviderBuilderOperator ServiceProviderBuilderOperator { get; } = F000.ServiceProviderBuilderOperator.Instance;
    }
}