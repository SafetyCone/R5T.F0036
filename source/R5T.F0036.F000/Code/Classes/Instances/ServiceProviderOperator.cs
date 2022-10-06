using System;


namespace R5T.F0036.F000
{
	public class ServiceProviderOperator : IServiceProviderOperator
	{
		#region Infrastructure

	    public static IServiceProviderOperator Instance { get; } = new ServiceProviderOperator();

	    private ServiceProviderOperator()
	    {
        }

	    #endregion
	}
}