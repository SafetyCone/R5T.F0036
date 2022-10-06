using System;


namespace R5T.F0036.F000
{
	public class HasServicesOperator : IHasServicesOperator
	{
		#region Infrastructure

	    public static IHasServicesOperator Instance { get; } = new HasServicesOperator();

	    private HasServicesOperator()
	    {
        }

	    #endregion
	}
}