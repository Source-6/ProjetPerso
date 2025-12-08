using UnityEngine;
using UnityEngine.AI;


public enum ItemType
{
    Glue,
    Honey,
    Trap,
}

[RequireComponent(typeof(NavMeshObstacle))]
public class Item : MonoBehaviour
{
    public ItemType itemType;
    private NavMeshObstacle navMeshObstacle;
    void Start()
    {
        navMeshObstacle = GetComponent<NavMeshObstacle>();
        navMeshObstacle.carving = true;
    }

}
