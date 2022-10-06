using System;


namespace R5T.F0036.F000
{
	public class ServicesBuilderOperator : IServicesBuilderOperator
	{
		#region Infrastructure

	    public static IServicesBuilderOperator Instance { get; } = new ServicesBuilderOperator();

	    private ServicesBuilderOperator()
	    {
        }

	    #endregion
	}
}