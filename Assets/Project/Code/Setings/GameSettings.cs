using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "Settings/GameSettings")]
public class GameSettings : ScriptableObject
{
    [Range(1, 5)]
    public int dronesPerTeam = 3;
    [Range(1, 10)]
    public float droneSpeed = 5;
    public float resourceSpawnCooldown = 0.5f;
    public bool showDronePath = true;
    public bool showTeamScore = true;



}
