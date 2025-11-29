using UnityEngine;

public class CraftingItems : MonoBehaviour
{
    [SerializeField] private PickupItems pickupItems;
    // private bool canCraft = false;

    public void Craft()
    {
        if (pickupItems.inventory.ContainsKey(pickupItems.realItemHoney) && pickupItems.inventory.ContainsKey(pickupItems.realItemGlue))
        {
            // canCraft = true;
        }
    }
} 
