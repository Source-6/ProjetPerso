using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    [Header("Rooms")]

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
        // Cursor.visible = true;
    }

    private void ObjectCreation()
    {
        // roomMaker = Instantiate(roomMaker);
        // player = Instantiate(player);
        
    }

    private void ObjectInitialise()
    {
        // roomMaker.Initialise();
        // ground.Initialize();
        player.Initialize();
    }

}
