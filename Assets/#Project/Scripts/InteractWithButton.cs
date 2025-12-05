using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InteractWithButton : MonoBehaviour
{
    [SerializeField] Transform playerPos;
    [SerializeField] CraftingItems craftingItems;
    [SerializeField] Button craftButton;
    [SerializeField] Button placeTrapButton;
    [SerializeField] private GameObject trap;
    [SerializeField] private PickupItems pickupItems;
    public int trapCount;



    public void Initialize()
    {
        craftButton = craftButton.GetComponent<Button>();
        craftButton.interactable = false;
        craftButton.onClick.AddListener(CreateTrap);
        trapCount = 0;

        placeTrapButton = placeTrapButton.GetComponent<Button>();
        placeTrapButton.interactable = false;
        placeTrapButton.onClick.AddListener(PlaceTrap);


    }

    public void Process()
    {
        if (craftingItems.canCraft)
        {
            craftButton.interactable = true;
        }
        if (trapCount >= 1)
        {
            placeTrapButton.interactable = true;
        }
    }

    public void CreateTrap()
    {
        if (trapCount == 0)
        {
            
            pickupItems.inventory.Clear();
            pickupItems.inventory.Add(ItemType.Trap, 1);
            trapCount++;
        }
    }

    public void PlaceTrap()
    {
        trap.transform.position = playerPos.position + Vector3.forward * 2 + Vector3.up *2;
        trap = Instantiate(trap);
    }
}
