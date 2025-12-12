using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayAlerts : MonoBehaviour
{
    [SerializeField] private PlayerBehavior player;
    [SerializeField] List<GameObject> alerts;
    private PickupItems pickupItems;
    private InteractWithDoor interactWithDoor;


    void Start()
    {
        pickupItems = player.GetComponent<PickupItems>();
        interactWithDoor = player.GetComponent<InteractWithDoor>();
        SetIncative();
    }
    void Update()
    {
        if (pickupItems.canPickUp)
        {
            SetIncative();
            alerts[0].SetActive(true);
        }
        if (interactWithDoor.canOpenDoor)
        {
            SetIncative();
            alerts[1].SetActive(true);
        }
        if (pickupItems.inventory.ContainsKey(ItemType.Glue) && pickupItems.inventory.ContainsKey(ItemType.Honey))
        {
            SetIncative();
            alerts[2].SetActive(true);
        }
        if (pickupItems.inventory.ContainsKey(ItemType.Trap))
        {
            SetIncative();
            alerts[3].SetActive(true);
        }
    }

    void SetIncative()
    {
        for (int i = 0; i < alerts.Count; i++)
        {
            alerts[i].SetActive(false);
        }
    }
}
