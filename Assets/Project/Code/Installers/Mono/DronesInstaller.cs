using UnityEngine;
using Zenject;

public class DronesInstaller : MonoInstaller
{
    [SerializeField] DroneAI dronePrefab;
    [SerializeField] DroneBase droneBasePrefab;
    [SerializeField] Transform redSpawn;
    [SerializeField] Transform redParent;
    [SerializeField] Transform blueSpawn;
    [SerializeField] Transform blueParent;
    public override void InstallBindings()
    {
        Container.BindInstance(dronePrefab).WithId("Prefab");
        Container.BindInstance(droneBasePrefab).WithId("Prefab");

        Container.BindInstance(redSpawn).WithId("RedSpawn");
        Container.BindInstance(redParent).WithId("RedParent");
        Container.BindInstance(blueSpawn).WithId("BlueSpawn");
        Container.BindInstance(blueParent).WithId("BlueParent");

        Container.BindFactory<Team, DroneAI, DroneFactory>().AsSingle();
        Container.BindFactory<Team, DroneBase, DroneBaseFactory>().AsSingle();


    }
}