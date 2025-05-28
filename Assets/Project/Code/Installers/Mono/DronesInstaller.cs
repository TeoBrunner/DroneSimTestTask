using UnityEngine;
using Zenject;

public class DronesInstaller : MonoInstaller
{
    [SerializeField] DroneAI dronePrefab;
    [SerializeField] DroneBase droneBasePrefab;
    [SerializeField] Transform redSpawn;
    [SerializeField] Transform blueSpawn;
    public override void InstallBindings()
    {
        Container.BindInstance(dronePrefab).WithId("Prefab");
        Container.BindInstance(droneBasePrefab).WithId("Prefab");

        Container.BindInstance(redSpawn).WithId("RedSpawn");
        Container.BindInstance(blueSpawn).WithId("BlueSpawn");

        Container.BindFactory<Team, DroneAI, DroneFactory>().AsSingle();
        Container.BindFactory<Team, DroneBase, DroneBaseFactory>().AsSingle();


    }
}