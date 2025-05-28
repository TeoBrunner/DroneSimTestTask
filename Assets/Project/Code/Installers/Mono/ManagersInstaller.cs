using UnityEngine;
using Zenject;

public class ManagersInstaller : MonoInstaller
{
    [SerializeField]GameSettingsManager gameSettingsManager;
    public override void InstallBindings()
    {
        Container.BindInstance(gameSettingsManager);
    }
}