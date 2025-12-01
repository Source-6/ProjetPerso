using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;

public class ChangeImage : MonoBehaviour
{
    public Image imageFirst;
    public Image imageSecond;
    [SerializeField] private PickupItems pickupItems;
    [SerializeField] GameObject ParentFirstImage;
    [SerializeField] GameObject ParentSecondImage;

    void Start()
    {
        ParentFirstImage.SetActive(false);
        ParentSecondImage.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pickupItems.item == null) return;

        if (pickupItems.inventory.ContainsKey(pickupItems.realItemGlue))
        {
            ParentFirstImage.SetActive(true);
        }
        else if (pickupItems.inventory.ContainsKey(pickupItems.realItemHoney))
        {
            ParentSecondImage.SetActive(true);
        }


    }
}
