using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InteractWithButton : MonoBehaviour
{
    [SerializeField] PlayerBehavior player;
    [SerializeField] Button craftButton;
    [SerializeField] Button placeTrapButton;
    [SerializeField] private GameObject trap;
    [SerializeField] private PickupItems pickupItems;
    [SerializeField] private ChangeImage changeImage;
    public int trapCount;
    [SerializeField] private int maxTrapCount;



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
        if (player.canCraft)
        {
            craftButton.interactable = true;
        }
        else if (!player.canCraft)
        {
            craftButton.interactable = false;
        }
        if (pickupItems.inventory.ContainsKey(ItemType.Trap))
        {
            placeTrapButton.interactable = true;
        }
    }

    public void CreateTrap()
    {
        if (!pickupItems.inventory.ContainsKey(ItemType.Trap))
        {
            pickupItems.inventory.Clear();
            pickupItems.inventory.Add(ItemType.Trap, 1);
            Debug.Log(pickupItems.inventory.Count);
            changeImage.UpdateSlots(ItemType.Trap);
            player.canCraft = false;

        }
    }

    public void PlaceTrap()
    {
        if (pickupItems.inventory.ContainsKey(ItemType.Trap))
        {
            trap.transform.position = player.transform.position + Vector3.forward * 2 + Vector3.up;
            trap = Instantiate(trap);
            pickupItems.inventory.Clear();
            placeTrapButton.interactable = false;
            
        }
    }
}
