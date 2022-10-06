using System;


namespace R5T.F0036.F000
{
	public class ServiceCollectionBuilderOperator : IServiceCollectionBuilderOperator
	{
		#region Infrastructure

	    public static IServiceCollectionBuilderOperator Instance { get; } = new ServiceCollectionBuilderOperator();

	    private ServiceCollectionBuilderOperator()
	    {
        }

	    #endregion
	}
}