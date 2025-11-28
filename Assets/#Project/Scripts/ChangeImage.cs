using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;

public class ChangeImage : MonoBehaviour
{
    public Image imageThis;
    public List<Sprite> sprites = new List<Sprite>();
    private PickupItems pickupItems;


    void Start()
    {
        imageThis = GetComponent<Image>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if (true)
        {
            imageThis.sprite = sprites[0];
        }
        // else if (pickupItems.inventory.TryGetValue("glue", out int vale))
        // {
        //     imageThis.sprite = sprites[1];
        // }
    }
}
