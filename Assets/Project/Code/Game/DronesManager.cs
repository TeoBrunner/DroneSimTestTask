using UnityEngine;
using Zenject;

public class DronesManager : MonoBehaviour
{
    private SignalBus signalBus;
    private DroneBaseFactory droneBaseFactory;
    private Transform redSpawn;
    private Transform redParent;
    private Transform blueSpawn;
    private Transform blueParent;

    [Inject]
    private void Construct(SignalBus signalBus,
                           DroneBaseFactory droneBaseFactory,
                           [Inject(Id = "RedSpawn")] Transform redSpawn,
                           [Inject(Id = "RedParent")] Transform redParent,
                           [Inject(Id = "BlueSpawn")] Transform blueSpawn,
                           [Inject(Id = "BlueParent")] Transform blueParent)
    {
        this.signalBus = signalBus;
        this.droneBaseFactory = droneBaseFactory;
        this.redSpawn = redSpawn;
        this.redParent = redParent;
        this.blueSpawn = blueSpawn;
        this.blueParent = blueParent;
    }
    void Start()
    {
        SpawnBase(Team.Red);
        SpawnBase(Team.Blue);
    }

    private void SpawnBase(Team team)
    {
        Transform spawn = null;
        Transform parent = null;
        if (team == Team.Red)
        {
            spawn = redSpawn;
            parent = redParent;
        }
        if( team == Team.Blue)
        {
            spawn = blueSpawn;
            parent = blueParent;
        }

        DroneBase droneBase = droneBaseFactory.Create(team);
        droneBase.name = team.ToString() + " Base";
        if (spawn)
        {
            droneBase.transform.parent = parent;
            droneBase.transform.position = spawn.position;
        }
    }

}
