using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InteractWithButton : MonoBehaviour
{
    [SerializeField] CraftingItems craftingItems;
    [SerializeField] Button craftButton;
    [SerializeField] private GameObject trap;
    [SerializeField] private PickupItems pickupItems;
    public int trapCount;



    public void Initialize()
    {
        craftButton = craftButton.GetComponent<Button>();
        craftButton.interactable = false;
        craftButton.onClick.AddListener(TaskOnClick);
        trapCount = 0;

    }

    public void Process()
    {
        if (craftingItems.canCraft)
        {
            craftButton.interactable = true;
        }
    }

    public void TaskOnClick()
    {
        if (trapCount == 0)
        {
            trap = Instantiate(trap);
            Debug.Log($"before : {pickupItems.inventory.Count}");
            pickupItems.inventory.Clear();
            Debug.Log($"after : {pickupItems.inventory.Count}");
            trapCount++;
        }
    }
}
