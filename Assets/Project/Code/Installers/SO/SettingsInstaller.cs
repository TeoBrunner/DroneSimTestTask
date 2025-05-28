using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "SettingsInstaller", menuName = "Installers/SettingsInstaller")]
public class SettingsInstaller : ScriptableObjectInstaller<SettingsInstaller>
{
    [SerializeField] GameSettings defaultSettings;
    [SerializeField] GameSettings currentSettings;
    public override void InstallBindings()
    {
        Container.BindInstance(currentSettings);
        Container.BindInstance(defaultSettings).WithId("Default");
    }
}