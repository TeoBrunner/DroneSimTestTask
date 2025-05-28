using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Zenject;

public class GameSettingsUIHandler : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    [SerializeField] Slider dronesPerTeamSlider;
    [SerializeField] TMP_Text dronesPerTeamIndicator;
    [SerializeField] Slider droneSpeedSlider;
    [SerializeField] TMP_Text droneSpeedIndicator;
    [SerializeField] TMP_InputField resourceSpawnCooldownField;
    [SerializeField] Toggle showDronePathToggle;
    [SerializeField] Toggle showTeamScore;
    [SerializeField] Button resetToDefaultButton;

    private SettingsManager SettingsManager;
    private SignalBus signalBus;

    [Inject]
    private void Construct(SettingsManager SettingsManager, 
                           SignalBus signalBus)
    {
        this.SettingsManager = SettingsManager;
        this.signalBus = signalBus;
    }
    private void Start()
    {
        UpdateUI();

        signalBus.Subscribe<GameSettingsChangedSignal>(UpdateUI);
        signalBus.Subscribe<StartGameSignal>(() => canvas.gameObject.SetActive(false));
    }
    private void SubscribeToUI()
    {
        dronesPerTeamSlider.onValueChanged.AddListener(OnDronesPerTeamChanged);
        droneSpeedSlider.onValueChanged.AddListener(OnDroneSpeedChanged);
        resourceSpawnCooldownField.onEndEdit.AddListener(OnResourceSpawnCooldownChanged);
        showDronePathToggle.onValueChanged.AddListener(OnShowDronePathChanged);
        showTeamScore.onValueChanged.AddListener(OnShowTeamScoreChanged);
        resetToDefaultButton.onClick.AddListener(OnResetToDefault);
    }
    private void UnsubscribeToUI()
    {
        dronesPerTeamSlider.onValueChanged.RemoveListener(OnDronesPerTeamChanged);
        droneSpeedSlider.onValueChanged.RemoveListener(OnDroneSpeedChanged);
        resourceSpawnCooldownField.onEndEdit.RemoveListener(OnResourceSpawnCooldownChanged);
        showDronePathToggle.onValueChanged.RemoveListener(OnShowDronePathChanged);
        showTeamScore.onValueChanged.RemoveListener(OnShowTeamScoreChanged);
        resetToDefaultButton.onClick.RemoveListener(OnResetToDefault);
    }
    private void UpdateUI()
    {
        UnsubscribeToUI();

        dronesPerTeamSlider.minValue = 1;
        dronesPerTeamSlider.maxValue = 5;
        dronesPerTeamSlider.wholeNumbers = true;
        dronesPerTeamSlider.value = SettingsManager.DronesPerTeam;
        dronesPerTeamIndicator.text = SettingsManager.DronesPerTeam.ToString();

        droneSpeedSlider.minValue = 1;
        droneSpeedSlider.maxValue = 10;
        droneSpeedSlider.value = SettingsManager.DroneSpeed;
        float droneSpeedRaw = SettingsManager.DroneSpeed;
        float droneSpeedRound = Mathf.Round(droneSpeedRaw * 10) * 0.1f;
        droneSpeedIndicator.text = droneSpeedRound.ToString();

        resourceSpawnCooldownField.text = SettingsManager.ResourceSpawnCooldown.ToString();

        showDronePathToggle.isOn = SettingsManager.ShowDronePath;

        showTeamScore.isOn = SettingsManager.ShowTeamScore;

        SubscribeToUI();
    }

    private void OnDronesPerTeamChanged(float value)
    {
        SettingsManager.SetDronesPerTeam((int)value);
    }
    private void OnDroneSpeedChanged(float value)
    {
        SettingsManager.SetDroneSpeed(value);
    }
    private void OnResourceSpawnCooldownChanged(string value)
    {
        if(float.TryParse(value, out float floatValue))
        {
            SettingsManager.SetResourceSpawnCooldown(floatValue);
        }
        else
        {
            resourceSpawnCooldownField.text = SettingsManager.ResourceSpawnCooldown.ToString();
        }
    }
    private void OnShowDronePathChanged(bool value)
    {
        SettingsManager.SetShowDronePath(value);
    }
    private void OnShowTeamScoreChanged(bool value)
    {
        SettingsManager.SetShowTeamScore(value);
    }
    private void OnResetToDefault()
    {
        SettingsManager.ResetToDefault();
    }

}
