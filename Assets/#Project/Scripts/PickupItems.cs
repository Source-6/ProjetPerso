using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TMPro;
using UnityEngine;
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
    #endregion


    [SerializeField] private InputActionAsset actions;
    [SerializeField] private GameObject fakeItem;
    public Dictionary<string, int> inventory = new Dictionary<string, int>();
    
    private Item item;
    
    [SerializeField] private GameObject realItem;

    [SerializeField] private TMP_Text testItem;


    private int testint = 0;
    private int val;


    private bool canPickUp = false;
    public bool inInventory = false;
    private bool canMakeTrap = false;


    private void OnEnable()
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
        if (fakeItem == null) return;
        PickUpItem();

    }

    public void PickUpItem()
    {
        if (canPickUp)
        {
            item = fakeItem.GetComponent<Item>();
            if (item.itemType == Item.ItemType.Glue)
            {
                inventory.Add("glue", 1);
                Destroy(fakeItem);
                Debug.Log($"inv : glue");
                Debug.Log(inventory["glue"]);
                Debug.Log(inventory.TryGetValue("glue", out int val));
                
                
            }
            else if (item.itemType == Item.ItemType.Honey)
            {
                inventory.Add("honey", 1);
                Destroy(fakeItem);

                Debug.Log(inventory["honey"]);
                Debug.Log(inventory.TryGetValue("honey", out int val));

            }
            
        
            

            
            
            
            
            
            // realItems.Add(realItem);
            // Destroy(fakeItem);
            // testint++;
            // testItem.text = testint.ToString();
            // Debug.Log(realItems.Count);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pickupable" && !inInventory)
        {
            canPickUp = true;
            fakeItem = other.gameObject;
            // inInventory = true;
            
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
