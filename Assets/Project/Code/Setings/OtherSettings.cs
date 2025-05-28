using UnityEngine;
[CreateAssetMenu(fileName = "OtherSettings", menuName = "Settings/OtherSettings")]
public class OtherSettings : ScriptableObject
{
    [SerializeField] float droneSize = 0.6f;
    [SerializeField] float droneSpawnRadius = 1f;
    [SerializeField] int maxResourcesOnField = 20;
    [SerializeField] float resourceSize = 0.3f;
    [SerializeField] float resourceSphereCastRadius = 0.5f;

    public float DroneSize => droneSize;
    public float DroneSpawnRadius => droneSpawnRadius;
    public int MaxResourcesOnField => maxResourcesOnField;
    public float ResourceSize => resourceSize;
    public float ResourceSphereCastRadius => resourceSphereCastRadius;
}
