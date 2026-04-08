using MyInventory2026.src.Modules.Provider.Domain.ValueObject;

namespace MyInventory2026.src.Modules.Provider.Domain.Aggregate;

public class ProviderAggregate   
{
    public ProviderId Id { get; private set; }
    public ProviderName Name { get; private set; }

    private ProviderAggregate(ProviderId id, ProviderName name)
    {
        Id = id;
        Name = name;
    }

    public static ProviderAggregate Create(string id, string name)
    {
        return new ProviderAggregate(
            ProviderId.Create(id),
            ProviderName.Create(name)
        );
    }
}