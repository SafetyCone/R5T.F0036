using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.T0142;


namespace R5T.F0036.T000
{
    [DraftUtilityTypeMarker]
    public interface IHasServices
    {
        IServiceCollection Services { get; }
    }
}
