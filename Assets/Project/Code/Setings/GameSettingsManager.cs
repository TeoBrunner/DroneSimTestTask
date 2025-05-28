using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Zenject;

public class GameSettingsManager : MonoBehaviour
{
    private GameSettings currentSettings;
    private GameSettings defaultSettings;
    private SignalBus signalBus;
    public int DronesPerTeam => currentSettings.dronesPerTeam;
    public float DroneSpeed => currentSettings.droneSpeed;
    public float ResourceSpawnCooldown => currentSettings.resourceSpawnCooldown;
    public bool ShowDronePath => currentSettings.showDronePath;
    public bool ShowTeamScore => currentSettings.showTeamScore;

    [Inject]
    private void Construct(GameSettings currentSettings,
                           [Inject(Id = "Default")] GameSettings defaultSettings,
                           SignalBus signalBus)
    {
        this.currentSettings = currentSettings;
        this.defaultSettings = defaultSettings;
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
