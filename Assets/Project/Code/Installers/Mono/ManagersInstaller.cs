using UnityEngine;
using Zenject;

public class ManagersInstaller : MonoInstaller
{
    [SerializeField] SettingsManager gameSettingsManager;
    [SerializeField] DronesManager dronesManager;
    [SerializeField] ResourcesManager resourcesManager;
    public override void InstallBindings()
    {
        Container.BindInstance(gameSettingsManager);
        Container.BindInstance(dronesManager);
        Container.BindInstance(resourcesManager);
    }
}