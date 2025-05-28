using UnityEngine;
using Zenject;

public class ManagersInstaller : MonoInstaller
{
    [SerializeField] GameSettingsManager gameSettingsManager;
    [SerializeField] GameManager gameManager;
    public override void InstallBindings()
    {
        Container.BindInstance(gameSettingsManager);
        Container.BindInstance(gameManager);
    }
}