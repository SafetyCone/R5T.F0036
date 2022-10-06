using System;


namespace R5T.F0036.F001
{
	public class ServicesConfigurerOperator : IServicesConfigurerOperator
	{
		#region Infrastructure

	    public static IServicesConfigurerOperator Instance { get; } = new ServicesConfigurerOperator();

	    private ServicesConfigurerOperator()
	    {
        }

	    #endregion
	}
}