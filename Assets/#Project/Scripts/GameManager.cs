using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerBehavior player;
    [SerializeField] private InteractWithButton interactWithButton;


    // Update is called once per frame
    void Update()
    {
        player.Process();
        interactWithButton.Process();
    }
}
