using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractWithDoor : MonoBehaviour
{
    [SerializeField] private InputActionAsset actions;
    private InputAction openDoor;

    private Transform door;
    private bool doorIsOpen;
    private bool canOpenDoor;
    private bool canCloseDoor;

    private Animator animator;

    public void Initialize()
    {
        doorIsOpen = false;
        canOpenDoor = false;

        openDoor = actions.FindActionMap("InteractInput").FindAction("Open");
    }

    private void OnEnable()
    {
        actions.FindActionMap("InteractInput").Enable();
        actions.FindActionMap("InteractInput").FindAction("Open").performed += OpenDoor;
    }

    private void OnDisable()
    {
        actions.FindActionMap("InteractInput").Disable();
        actions.FindActionMap("InteractInput").FindAction("Open").performed -= OpenDoor;

    }

    private void OpenDoor(InputAction.CallbackContext callbackContext)
    {
        if (door == null) return;

        animator = door.GetComponent<Animator>();
        if (canOpenDoor)
        {
            // door.transform.Rotate(0, 0, 80f, Space.Self);  //rotate on z bc blender(duh)
            doorIsOpen = true;
            animator.SetBool("isOpenning", doorIsOpen);

        }
        if (doorIsOpen)
        {
            canOpenDoor = false;
            animator.SetBool("isOpenning", doorIsOpen);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Door" && !doorIsOpen)
        {
            canOpenDoor = true;
            door = other.transform;
        }
    }

    void OnTriggerExit(Collider other)
    {
         if (other.gameObject.tag == "Door")
        {
            canOpenDoor = false;
            door = null;
        }
    }

}
