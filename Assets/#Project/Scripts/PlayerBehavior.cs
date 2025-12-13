using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerBehavior : MonoBehaviour
{
    #region old code
    // [SerializeField] private InputActionAsset actions;
    // private InputAction xAxis;
    // private InputAction zAxis;
    // [SerializeField] private float speed;
    // void Start()
    // {
    //     xAxis = actions.FindActionMap("PlayerMove").FindAction("xAxis");
    //     zAxis = actions.FindActionMap("PlayerMove").FindAction("zAxis");
    // }

    // void OnEnable()
    // {
    //     actions.FindActionMap("PlayerMove").Enable();
    // }
    // void OnDisable()
    // {
    //     actions.FindActionMap("PlayerMove").Disable();
    // }

    // void Update()
    // {
    //     PlayerMove();
    // }


    // void PlayerMove()
    // {
    //     float xMove = xAxis.ReadValue<float>();
    //     float zMove = zAxis.ReadValue<float>();

    //     Vector3 move = new Vector3(xMove,0f,zMove);
    //     Vector3 movement = speed * Time.deltaTime * move;
    //     transform.Translate(movement);
    // }
    #endregion

    [SerializeField] Transform startingPos;
    [SerializeField] EnemyBehavior enemy;
    [SerializeField] public int playerLife;

    //Items :
    [SerializeField] private InputActionAsset actions;
    [SerializeField] private PickupItems pickupItems;
    [SerializeField] private GameObject craftingStation;
    public bool canCraft;


    public void Initialize()
    {
        transform.position = startingPos.position;
    }


    void OnEnable()
    {
        actions.FindActionMap("InteractInput").Enable();
        actions.FindActionMap("InteractInput").FindAction("PickUp").performed += PickUpItemAction;
    }

    private void OnDisable()
    {
        actions.FindActionMap("InteractInput").Disable();
        actions.FindActionMap("InteractInput").FindAction("PickUp").performed -= PickUpItemAction;
    }

    private void PickUpItemAction(InputAction.CallbackContext callbackContext)
    {
        if (pickupItems.fakeItem == null) return;
        pickupItems.PickUpItem();

    }

    public void Process()
    {
        if (playerLife <= 0)
        {
            Debug.Log("player is dead");
        }
        Debug.Log(playerLife);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CraftingStation")
        {
            if (pickupItems.inventory.ContainsKey(ItemType.Glue) && pickupItems.inventory.ContainsKey(ItemType.Honey))
            {
                canCraft = true;
                Debug.Log("enter");
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "CraftingStation")
        {
            canCraft = false;
            Debug.Log("exit");
        }
    }











}
