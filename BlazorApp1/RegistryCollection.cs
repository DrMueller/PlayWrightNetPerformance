using Lamar;

namespace Mmu.CleanBlazor.Presentation2;

public class RegistryCollection : ServiceRegistry
{
    public RegistryCollection()
    {
        Scan(scanner =>
        {
            scanner.AssemblyContainingType<RegistryCollection>();
            scanner.WithDefaultConventions();
        });
    }
}