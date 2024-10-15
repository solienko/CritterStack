using Wolverine;

namespace CritterStack.Common;

public abstract class ModuleBase : IWolverineExtension
{
    public string? ConnectionString { get; set; }

    public abstract void Configure(WolverineOptions options);
}
