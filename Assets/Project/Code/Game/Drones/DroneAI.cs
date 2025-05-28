using UnityEngine;
using Zenject;

public class DroneAI : MonoBehaviour
{
    private Team team;
    private SettingsManager settingsManager;

    [Header("Visuals")]
    [SerializeField] MeshRenderer bodyRenderer;

    [Inject]
    private void Construct(SettingsManager settingsManager)
    {
        this.settingsManager = settingsManager;
    }
    public void Initialize(Team team) 
    {
        this.team = team;
        float size = settingsManager.Other.DroneSize;

        if (team == Team.Red)
        {
            bodyRenderer.material.color = Color.red;
        }
        if (team == Team.Blue)
        {
            bodyRenderer.material.color = Color.blue;
        }

        transform.localScale = Vector3.one * size;
    }
}
