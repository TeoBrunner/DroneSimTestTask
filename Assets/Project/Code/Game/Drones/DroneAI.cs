using UnityEngine;

public class DroneAI : MonoBehaviour
{
    private Team team;

    [Header("Visuals")]
    [SerializeField] MeshRenderer bodyRenderer;

    public void Initialize(Team team) 
    {
        this.team = team;

        if (team == Team.Red)
        {
            bodyRenderer.material.color = Color.red;
        }
        if (team == Team.Blue)
        {
            bodyRenderer.material.color = Color.blue;
        }
    }
}
