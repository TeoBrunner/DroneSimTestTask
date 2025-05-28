using UnityEngine;
using Zenject;

public class DroneBaseFactory : PlaceholderFactory<Team, DroneBase>
{
    private DiContainer container;
    private DroneBase droneBasePrefab;
    public DroneBaseFactory(DiContainer container,
                            [Inject(Id = "Prefab")] DroneBase droneBasePrefab)
    {
        this.container = container;
        this.droneBasePrefab = droneBasePrefab;
    }
    public override DroneBase Create(Team team)
    {
        DroneBase droneBase = container.InstantiatePrefabForComponent<DroneBase>(droneBasePrefab);
        droneBase.Initialize(team);

        return droneBase;
    }
}
