using UnityEngine;
using Zenject;

public class GameManager : MonoBehaviour
{
    private SignalBus signalBus;
    private DroneBaseFactory droneBaseFactory;
    private Transform redSpawn;
    private Transform blueSpawn;

    [Inject]
    private void Construct(SignalBus signalBus,
                           DroneBaseFactory droneBaseFactory,
                           [Inject(Id = "RedSpawn")] Transform redSpawn,
                           [Inject(Id = "BlueSpawn")] Transform blueSpawn)
    {
        this.signalBus = signalBus;
        this.droneBaseFactory = droneBaseFactory;
        this.redSpawn = redSpawn;
        this.blueSpawn = blueSpawn;
    }
    void Start()
    {
        SpawnBase(Team.Red);
        SpawnBase(Team.Blue);
    }

    private void SpawnBase(Team team)
    {
        Transform spawn = null;
        if (team == Team.Red)
        {
            spawn = redSpawn;
        }
        if( team == Team.Blue)
        {
            spawn = blueSpawn;
        }

        DroneBase droneBase = droneBaseFactory.Create(team);
        if (spawn)
        {
            droneBase.transform.position = spawn.position;
        }
    }

}
