using UnityEngine;
using Zenject;

public class ResourcesInstaller : MonoInstaller
{
    [SerializeField] Resource resourcePrefab;
    [SerializeField] Collider resourcesSpawnZone;
    [SerializeField] Transform resourcesParent;
    public override void InstallBindings()
    {
        Container.BindInstance(resourcePrefab).WithId("Prefab");
        Container.BindInstance(resourcesSpawnZone).WithId("ResourcesSpawnZone");
        Container.BindInstance(resourcesParent).WithId("ResourcesParent");

        Container.BindFactory<Resource, ResourcesFactory>().AsSingle();
    }
}