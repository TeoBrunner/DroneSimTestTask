using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GameStartUIHandler : MonoBehaviour
{
    private SignalBus signalBus;

    [SerializeField] Canvas canvas;
    [SerializeField] Button startButton;

    [Inject]
    private void Construct(SignalBus signalBus)
    {
        this.signalBus = signalBus;
    }
    private void Start()
    {
        startButton.onClick.AddListener(OnStartButtonPressed);
    }
    private void OnStartButtonPressed()
    {
        canvas.gameObject.SetActive(false);
        signalBus.Fire<StartGameSignal>();
    }
}
