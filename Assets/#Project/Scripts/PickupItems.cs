using UnityEngine;
using UnityEngine.InputSystem;

public class PickupItems : MonoBehaviour
{
    [SerializeField] private InputActionAsset actions;
    private InputAction pickup;
    private bool canPickUp;
    private bool hasItem;
    

    private GameObject item;

    public void Initialize()
    {
        canPickUp = false;
        hasItem = false;

        pickup = actions.FindActionMap("InteractInput").FindAction("Pickup");
    }

    private void OnEnable()
    {
        actions.FindActionMap("InteractInput").Enable();
        actions.FindActionMap("InteractInput").FindAction("Pickup").performed += PickUp;
    }
    private void OnDisable()
    {
        actions.FindActionMap("InteractInput").Disable();
        
    }

    private void PickUp(InputAction.CallbackContext callbackContext)
    {
        if (canPickUp)
        {
            item.GetComponent<Rigidbody>().isKinematic = true;
            item.transform.position = transform.position + Vector3.forward * 2;
            
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pickupable")
        {
            canPickUp = true;
            item = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        canPickUp = false;
    }

}
