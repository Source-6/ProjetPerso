using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractWithDoor : MonoBehaviour
{
    [SerializeField] private InputActionAsset actions;


    [SerializeField]private Transform door;
    private bool doorIsOpen;
    public bool canOpenDoor;
    private bool closeDoor;

    private Animator animator;

    public void Initialize()
    {
        doorIsOpen = false;
        canOpenDoor = false;
        // closeDoor = true;

    }

    private void OnEnable()
    {
        actions.FindActionMap("InteractInput").Enable();
        actions.FindActionMap("InteractInput").FindAction("Open").performed += OpenDoorAction;
    }

    private void OnDisable()
    {
        actions.FindActionMap("InteractInput").Disable();
        actions.FindActionMap("InteractInput").FindAction("Open").performed -= OpenDoorAction;

    }

    private void OpenDoorAction(InputAction.CallbackContext callbackContext)
    {

        if (door == null) return;

        DoorReaction();
    }

    public void DoorReaction()
    {
        animator = door.GetComponent<Animator>();
        if (canOpenDoor)
        {
            // door.transform.Rotate(0, 0, 80f, Space.Self);  //rotate on z bc blender(duh)  --> now rotating with animation
            doorIsOpen = true;
            animator.SetBool("isOpenning", doorIsOpen);

        }
        if (doorIsOpen)
        {
            canOpenDoor = false;
            animator.SetBool("isOpenning", doorIsOpen);

        }
        if (closeDoor)  
        {
            doorIsOpen = false;

            animator.SetBool("isOpenning", doorIsOpen);
            animator.SetBool("isClosing", closeDoor);
            door = null;


        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Door" && !doorIsOpen)
        {
            closeDoor = false;
            canOpenDoor = true;
            door = other.transform;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Door")
        {
            canOpenDoor = false;
            doorIsOpen = false;
            closeDoor = true;
            DoorReaction();
        }
    }

}
