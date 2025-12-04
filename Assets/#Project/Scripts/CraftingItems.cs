using UnityEngine;

public class CraftingItems : MonoBehaviour
{
    [SerializeField] private PickupItems pickupItems;
    public bool canCraft = false;


    public void CanCraft()
    {
        if (pickupItems.inventory.ContainsKey(ItemType.Glue) && pickupItems.inventory.ContainsKey(ItemType.Honey))
        {
            canCraft = true;
        }
    }


} 
