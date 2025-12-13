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
    [Header("UI elements")]
    [SerializeField] InteractWithButton buttons;

    [Space]
    [Header("Game Manager")]
    [SerializeField] GameManager gameManager;




    void Start()
    {
        ObjectInitialise();
        ObjectCreation();


    }

    private void ObjectCreation()
    {
        player = Instantiate(player);
        enemy = Instantiate(enemy);
    }

    private void ObjectInitialise()
    {
        player.Initialize();
        buttons.Initialize();
        enemy.Initialize();
    }

}
