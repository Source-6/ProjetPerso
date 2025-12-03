using UnityEngine;

public class CraftingItems : MonoBehaviour
{
    [SerializeField] private PickupItems pickupItems;
    public bool canCraft = false;
    

    public void Craft()
    {
        if (!canCraft)
        {
            if (pickupItems.inventory.ContainsKey(pickupItems.realItemHoney) && pickupItems.inventory.ContainsKey(pickupItems.realItemGlue))
            {
                canCraft = true;
            }


        }
    }
} 
