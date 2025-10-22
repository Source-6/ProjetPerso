using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    [Header("Rooms")]
    [SerializeField] RoomMaker roomMaker;
    [SerializeField] GroundGenerator ground;

    [Space]
    [Header("Player")]
    [SerializeField] PlayerBehavior player;

    [Space]
    [Header("Enemy")]
    [SerializeField] EnemyBehavior enemy;

    [Space]
    [Header("Game Manager")]
    [SerializeField] GameManager gameManager;



    void Start()
    {
        // ObjectCreation();
        ObjectInitialise();
    }

    private void ObjectCreation()
    {
        // roomMaker = Instantiate(roomMaker);
        
    }

    private void ObjectInitialise()
    {
        // roomMaker.Initialise();
        ground.Initialise();
    }

}
