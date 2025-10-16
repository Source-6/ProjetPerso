using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    // [SerializeField] Rooms rooms;
    [SerializeField] FirstRoom firstRoom;
    void Start()
    {
        ObjectCreation();
        ObjectInitialise();
        // rooms.Draw();
    }

    private void ObjectCreation()
    {
        // rooms = Instantiate(rooms);
        
    }

    private void ObjectInitialise()
    {
        // rooms.Initialise(3, 3, 3, 3);
    }

}
