using UnityEngine;
using Zenject;

public class DroneFactory : PlaceholderFactory<Team, DroneAI>
{
    private DiContainer diContainer;
    private DroneAI dronePrefab;
    public DroneFactory (DiContainer diContainer,
                         [Inject(Id ="Prefab")]DroneAI prefab)
    {
        this.diContainer = diContainer;
        this.dronePrefab = prefab;
    }
    public override DroneAI Create(Team team)
    {
        DroneAI drone = diContainer.InstantiatePrefabForComponent<DroneAI>(dronePrefab);
        drone.name = "Drone " + team.ToString();
        drone.Initialize(team);

        return drone;
    }
}
