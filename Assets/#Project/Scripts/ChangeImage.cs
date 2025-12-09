using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;

public class ChangeImage : MonoBehaviour
{
    public Image imageFirst;
    public Image imageSecond;
    public Image imageThird;
    [SerializeField] private PickupItems pickupItems;
    [SerializeField] GameObject ParentFirstImage;
    [SerializeField] GameObject ParentSecondImage;
    [SerializeField] GameObject ParentThirdImage;


    void Start()
    {
        ParentFirstImage.SetActive(false);
        ParentSecondImage.SetActive(false);
        ParentThirdImage.SetActive(false);
        
    }

    public void UpdateSlots(ItemType itemType)
    {
        switch (itemType)
        {
            case ItemType.Glue:
                ParentFirstImage.SetActive(true);
                break;

            case ItemType.Honey:
                ParentSecondImage.SetActive(true);
                break;
            
            case ItemType.Trap:
                ParentThirdImage.SetActive(true);
                break;
        }
    }

    void Update()
    {
        
        
        // if (pickupItems.item == null) return;

        // if (pickupItems.inventory.ContainsKey(ItemType.Glue))
        // {
        //     ParentFirstImage.SetActive(true);
        // }
        // else if (pickupItems.inventory.ContainsKey(ItemType.Honey))
        // {
        //     ParentSecondImage.SetActive(true);
        // }

        // if (pickupItems.inventory.Count == 0)
        // {
        //     Debug.Log("something happened...");
        //     ParentFirstImage.SetActive(false);
        //     ParentSecondImage.SetActive(false);
        // }


    }
}
