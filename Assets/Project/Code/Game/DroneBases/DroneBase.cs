using UnityEngine;
using Zenject;

public class DroneBase : MonoBehaviour
{
    private SignalBus signalBus;
    private GameSettingsManager gameSettingsManager;
    private DroneFactory droneFactory;


    [Header("Settings")]
    [SerializeField] Team team;
    [SerializeField] float spawnRadius = 2;
    [Header("Visuals")]
    [SerializeField] MeshRenderer bodyRenderer;

    [Inject]
    private void Construct(SignalBus signalBus, 
                           GameSettingsManager gameSettingsManager,
                           DroneFactory droneFactory)
    {
        this.signalBus = signalBus;
        this.gameSettingsManager = gameSettingsManager;
        this.droneFactory = droneFactory;
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

        foreach (Vector3 spawnPoint in spawnPoints) 
        {

            DroneAI drone =  droneFactory.Create(team);
            drone.transform.parent = transform;
            drone.transform.position = spawnPoint;
        }
    }

    private Vector3[] GetSpawnPoints()
    {
        int teamSize = gameSettingsManager.DronesPerTeam;
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
