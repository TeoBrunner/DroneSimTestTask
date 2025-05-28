using UnityEngine;
using Zenject;

public class DroneBase : MonoBehaviour
{
    private SignalBus signalBus;
    private SettingsManager SettingsManager;
    private DroneFactory droneFactory;
    private Transform redParent;
    private Transform blueParent;

    private Team team;
    [Header("Visuals")]
    [SerializeField] MeshRenderer bodyRenderer;

    [Inject]
    private void Construct(SignalBus signalBus,
                           SettingsManager SettingsManager,
                           DroneFactory droneFactory,
                           [Inject(Id = "RedParent")] Transform redParent,
                           [Inject(Id = "BlueParent")] Transform blueParent)
    {
        this.signalBus = signalBus;
        this.SettingsManager = SettingsManager;
        this.droneFactory = droneFactory;
        this.redParent = redParent;
        this.blueParent = blueParent;
    }

    void Start()
    {
        signalBus.Subscribe<StartGameSignal>(SpawnDrones);
    }
    public void Initialize(Team team)
    {
        this.team = team;
        if(team == Team.Red)
        {
            bodyRenderer.material.color = Color.red;
        }
        if(team == Team.Blue)
        {
            bodyRenderer.material.color = Color.blue;
        }
    }
    private void SpawnDrones()
    {
        Vector3[] spawnPoints = GetSpawnPoints();
        Transform parent = null;

        if(team == Team.Red)
        {
            parent = redParent;
        }
        if(team == Team.Blue)
        {
            parent = blueParent;
        }

        foreach (Vector3 spawnPoint in spawnPoints) 
        {
            DroneAI drone =  droneFactory.Create(team);
            drone.transform.parent = parent;
            drone.transform.position = spawnPoint;
        }
    }

    private Vector3[] GetSpawnPoints()
    {
        int teamSize = SettingsManager.DronesPerTeam;
        float spawnRadius = SettingsManager.Other.DroneSpawnRadius;
        Vector3[] spawnPoints = new Vector3[teamSize];
        for (int i = 0; i < teamSize; i++)
        {
            float angle = i * Mathf.PI * 2 / teamSize;

            Vector3 offset = Vector3.zero;
            offset.x = Mathf.Cos(angle) * spawnRadius;
            offset.z = Mathf.Sin(angle) * spawnRadius;

            Vector3 spawnPoint = transform.position + offset;

            spawnPoints[i] = spawnPoint;
        }

        return spawnPoints;
    }

}
