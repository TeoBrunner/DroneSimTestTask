using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "SignalBusInstaller", menuName = "Installers/SignalBusInstaller")]
public class SignalBusInstaller : ScriptableObjectInstaller<SignalBusInstaller>
{
    public override void InstallBindings()
    {
        Zenject.SignalBusInstaller.Install(Container);

        Container.DeclareSignal<GameSettingsChangedSignal>();
        Container.DeclareSignal<StartGameSignal>();
    }
}