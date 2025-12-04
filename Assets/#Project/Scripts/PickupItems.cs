using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PickupItems : MonoBehaviour
{
    #region old code
    // [SerializeField] private InputActionAsset actions;
    // private InputAction pickup;
    // private bool canPickUp;
    // private bool hasItem;


    // private GameObject item;

    // public void Initialize()
    // {
    //     canPickUp = false;
    //     hasItem = false;

    //     pickup = actions.FindActionMap("InteractInput").FindAction("Pickup");
    // }

    // private void OnEnable()
    // {
    //     actions.FindActionMap("InteractInput").Enable();
    //     actions.FindActionMap("InteractInput").FindAction("Pickup").performed += PickUp;
    // }
    // private void OnDisable()
    // {
    //     actions.FindActionMap("InteractInput").Disable();

    // }

    // private void PickUp(InputAction.CallbackContext callbackContext)
    // {
    //     if (canPickUp)
    //     {
    //         item.GetComponent<Rigidbody>().isKinematic = true;
    //         item.transform.position = transform.position + Vector3.forward * 2;
    //         Debug.Log(canPickUp);


    //     }
    // }

    // private void OnTriggerEnter(Collider other)
    // {
    //     if (other.gameObject.tag == "Pickupable")
    //     {
    //         canPickUp = true;
    //         item = other.gameObject;
    //     }
    // }

    // private void OnTriggerExit(Collider other)
    // {
    //     canPickUp = false;
    // }



    // --- old pickup 
    // public void PickUpItem()
    // {
    //     if (canPickUp)
    //     {
    //         item = fakeItem.GetComponent<Item>();
    //         if (item.itemType == Item.ItemType.GlueFake)
    //         {
    //             inventory.Add(realItemGlue, 1);
    //             Destroy(fakeItem);
    //             Debug.Log(inventory[realItemGlue]);
    //             Debug.Log(inventory.TryGetValue(realItemGlue, out int val));


    //         }
    //         else if (item.itemType == Item.ItemType.HoneyFake)
    //         {
    //             inventory.Add(realItemHoney, 1);

    //             Destroy(fakeItem);

    //             Debug.Log(inventory[realItemHoney]);
    //             Debug.Log(inventory.TryGetValue(realItemHoney, out int val));
    //             inventory.Remove(realItemGlue);

    //         }


    //         // realItems.Add(realItem);
    //         // Destroy(fakeItem);
    //         // testint++;
    //         // testItem.text = testint.ToString();
    //         // Debug.Log(realItems.Count);
    //     }
    // }
    #endregion


    [SerializeField] private InputActionAsset actions;
    public UnityEvent<ItemType> onItemPickup;
    [SerializeField] public GameObject fakeItem;
    public Dictionary<ItemType, int> inventory = new();
    
    public Item item;

    [SerializeField] private TMP_Text testItem;

    private bool canPickUp = false;
    public bool inInventory = false;
    // private bool canMakeTrap = false;

    
    public void PickUpItem()
    {
        if (canPickUp)
        {
            item = fakeItem.GetComponent<Item>();
            inventory.Add(item.itemType, 1);
            Destroy(fakeItem);
            onItemPickup?.Invoke(item.itemType);
         
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pickupable" && !inInventory)
        {
            canPickUp = true;
            fakeItem = other.gameObject;
            
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Pickupable")
        {
            canPickUp = false;
        }
    }
}
