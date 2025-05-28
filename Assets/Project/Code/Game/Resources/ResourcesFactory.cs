using UnityEngine;
using Zenject;

public class ResourcesFactory : PlaceholderFactory<Resource>
{
    private DiContainer container;
    private Resource resourcePrefab;
    public ResourcesFactory(DiContainer container,
                            [Inject(Id = "Prefab")]Resource resourcePrefab)
    {
        this.container = container;
        this.resourcePrefab = resourcePrefab;
    }

    public override Resource Create()
    {
        Resource resource = container.InstantiatePrefabForComponent<Resource>(resourcePrefab);
        resource.Initialize();
        return resource;
    }
}
