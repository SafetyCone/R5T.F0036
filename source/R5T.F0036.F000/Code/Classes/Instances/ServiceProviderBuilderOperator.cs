using System;


namespace R5T.F0036.F000
{
	public class ServiceProviderBuilderOperator : IServiceProviderBuilderOperator
	{
		#region Infrastructure

	    public static IServiceProviderBuilderOperator Instance { get; } = new ServiceProviderBuilderOperator();

	    private ServiceProviderBuilderOperator()
	    {
        }

	    #endregion
	}
}