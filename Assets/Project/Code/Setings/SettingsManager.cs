using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Zenject;

public class SettingsManager : MonoBehaviour
{
    private GameSettings currentSettings;
    private GameSettings defaultSettings;
    private OtherSettings otherSettings;
    private SignalBus signalBus;
    public int DronesPerTeam => currentSettings.dronesPerTeam;
    public float DroneSpeed => currentSettings.droneSpeed;
    public float ResourceSpawnCooldown => currentSettings.resourceSpawnCooldown;
    public bool ShowDronePath => currentSettings.showDronePath;
    public bool ShowTeamScore => currentSettings.showTeamScore;
    public OtherSettings Other => otherSettings;

    [Inject]
    private void Construct(GameSettings currentSettings,
                           [Inject(Id = "Default")] GameSettings defaultSettings,
                           OtherSettings otherSettings,
                           SignalBus signalBus)
    {
        this.currentSettings = currentSettings;
        this.defaultSettings = defaultSettings;
        this.otherSettings = otherSettings;
        this.signalBus = signalBus;
    }
    public void SetDronesPerTeam (int dronesPerTeam)
    {
        currentSettings.dronesPerTeam = dronesPerTeam;
        signalBus.Fire<GameSettingsChangedSignal>();
    }
    public void SetDroneSpeed(float  droneSpeed)
    {
        currentSettings.droneSpeed = droneSpeed;
        signalBus.Fire<GameSettingsChangedSignal>();
    }
    public void SetResourceSpawnCooldown(float resourceSpawnCooldown)
    {
        currentSettings.resourceSpawnCooldown = resourceSpawnCooldown;
        signalBus.Fire<GameSettingsChangedSignal>();
    }
    public void SetShowDronePath(bool showDronePath)
    {
        currentSettings.showDronePath = showDronePath;
        signalBus.Fire<GameSettingsChangedSignal>();
    }
    public void SetShowTeamScore(bool showTeamScore)
    {
        currentSettings.showTeamScore = showTeamScore;
        signalBus.Fire<GameSettingsChangedSignal>();
    }
    public void ResetToDefault()
    {
        currentSettings.dronesPerTeam = defaultSettings.dronesPerTeam;
        currentSettings.droneSpeed = defaultSettings.droneSpeed;
        currentSettings.resourceSpawnCooldown = defaultSettings.resourceSpawnCooldown;
        currentSettings.showDronePath = defaultSettings.showDronePath;
        currentSettings.showTeamScore = defaultSettings.showTeamScore;

        signalBus.Fire<GameSettingsChangedSignal>();
    }
}
