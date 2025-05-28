using TMPro;
using UnityEngine;
using Zenject;

public class ScoreboardUIHandler : MonoBehaviour
{
    private SignalBus signalBus;
    private GameSettings gameSettings;

    [SerializeField] Canvas canvas;
    [SerializeField] TMP_Text red;
    [SerializeField] TMP_Text blue;

    [Inject]
    private void Construct(SignalBus signalBus,
                           GameSettings gameSettings)
    {
        this.signalBus = signalBus;
        this.gameSettings = gameSettings;
    }
    void Start()
    {
        canvas.gameObject.SetActive(false);
        signalBus.Subscribe<StartGameSignal>(OnStartGame);
        signalBus.Subscribe<ScoreboardUpdateSignal>(OnScoreboardUpdate);
    }
    private void OnStartGame()
    {
        if (gameSettings.showTeamScore)
        {
            canvas.gameObject.SetActive(true);
        }
    }
    private void OnScoreboardUpdate(ScoreboardUpdateSignal signal)
    {
        red.text = signal.data.red.ToString();
        blue.text = signal.data.blue.ToString();
    }
}
