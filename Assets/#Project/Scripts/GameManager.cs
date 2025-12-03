using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerBehavior player;


    // Update is called once per frame
    void Update()
    {
        player.Process();
    }
}
