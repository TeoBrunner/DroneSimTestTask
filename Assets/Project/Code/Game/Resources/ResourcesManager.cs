using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ResourcesManager : MonoBehaviour
{
    private SignalBus signalBus;
    private SettingsManager SettingsManager;
    private ResourcesFactory resourcesFactory;
    private Collider resourcesSpawnZone;
    private Transform resourcesParent;

    private List<Resource> resources = new List<Resource>();

    [Inject]
    private void Construct(SignalBus signalBus,
                           SettingsManager SettingsManager,
                           ResourcesFactory resourcesFactory,
                           [Inject(Id = "ResourcesSpawnZone")] Collider resourcesSpawnZone,
                           [Inject(Id = "ResourcesParent")] Transform resourcesParent)
    {
        this.signalBus = signalBus;
        this.SettingsManager = SettingsManager;
        this.resourcesFactory = resourcesFactory;
        this.resourcesSpawnZone = resourcesSpawnZone;
        this.resourcesParent = resourcesParent;
    }

    private void Start()
    {
        signalBus.Subscribe<StartGameSignal>(StartSpawn);

        signalBus.Subscribe<ResourceSpawnedSignal>(s => resources.Add(s.instance));
        signalBus.Subscribe<ResourceDestroyedSignal>(s => resources.Remove(s.instance));
    }

    private void StartSpawn()
    {
        StartCoroutine(SpawnCoroutine());
    }

    private IEnumerator SpawnCoroutine()
    {
        float cooldown = SettingsManager.ResourceSpawnCooldown;
        int maxResources = SettingsManager.Other.MaxResourcesOnField;
        while (true)
        {
            if(resources.Count<= maxResources && TryGetSpawnPos(out Vector3 spawnPos))
            {
                Resource resource = resourcesFactory.Create();
                resource.transform.parent = resourcesParent;
                resource.transform.position = spawnPos;
            }
            yield return new WaitForSeconds(cooldown);
        }
    }

    private bool TryGetSpawnPos(out Vector3 spawnPos)
    {
        Vector3 spawnZonePos = resourcesSpawnZone.transform.position;
        Vector3 spawnZoneSize = resourcesSpawnZone.bounds.size;
        int attemps = 100;
        for (int i = 0; i < attemps; i++)
        {

            Vector3 attempt = Vector3.zero;
            attempt.x = Random.Range(spawnZonePos.x + spawnZoneSize.x / 2, spawnZonePos.x - spawnZoneSize.x / 2);
            attempt.z = Random.Range(spawnZonePos.z + spawnZoneSize.z / 2, spawnZonePos.z - spawnZoneSize.z / 2);
            RaycastHit[] hits =  Physics.SphereCastAll(attempt, SettingsManager.Other.ResourceSphereCastRadius, Vector3.up);
            if(hits.Length==0 || (hits.Length==1 && hits[0].transform.name == "Ground")) //doubtful, but okay
            {
                spawnPos = attempt;
                return true;
            }
        }
        Debug.LogWarning("Could not find free space to spawn resource.");
        spawnPos = Vector3.zero;
        return false;
    }
}
