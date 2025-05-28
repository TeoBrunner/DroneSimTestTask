using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "SettingsInstaller", menuName = "Installers/SettingsInstaller")]
public class SettingsInstaller : ScriptableObjectInstaller<SettingsInstaller>
{
    [SerializeField] GameSettings currentSettings;
    [SerializeField] GameSettings defaultSettings;
    [SerializeField] OtherSettings otherSettings;

    public override void InstallBindings()
    {
        Container.BindInstance(currentSettings);
        Container.BindInstance(defaultSettings).WithId("Default");
        Container.BindInstance(otherSettings);
    }
}