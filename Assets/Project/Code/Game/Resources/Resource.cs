using UnityEngine;
using Zenject;

public class Resource : MonoBehaviour
{
    private bool isAvailable = true;
    private SignalBus signalBus;
    private SettingsManager settingsManager;

    public bool IsAvailable => isAvailable;

    [Inject]
    private void Construct(SignalBus signalBus,
                           SettingsManager settingsManager)
    {
        this.signalBus = signalBus;
        this.settingsManager = settingsManager;
    }
    private void Start()
    {
        signalBus.Fire<ResourceSpawnedSignal>(new ResourceSpawnedSignal { instance = this});
    }
    private void OnDestroy()
    {
        signalBus.Fire<ResourceDestroyedSignal>(new ResourceDestroyedSignal() { instance = this});
    }
    public void Initialize()
    {
        float size = settingsManager.Other.ResourceSize;
        transform.localScale = Vector3.one * size;
    }
    public void Reserve()
    {
        isAvailable = false;
    }
}
