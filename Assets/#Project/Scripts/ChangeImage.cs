using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;

public class ChangeImage : MonoBehaviour
{
    public Image imageThis;
    public List<Sprite> sprites = new List<Sprite>();
    [SerializeField] private PickupItems pickupItems;


    void Start()
    {
        imageThis = GetComponent<Image>();
        
    }

    // Update is called once per frame
    void Update()
    {
        // if (pickupItems.inventory.ContainsKey(pickupItems.realItemHoney))
        // {
        //     imageThis.sprite = sprites[1];
        // }
        // else if (pickupItems.inventory.ContainsKey(pickupItems.realItemGlue))
        // {
        //     imageThis.sprite = sprites[0];
        // }
        
    }
}
