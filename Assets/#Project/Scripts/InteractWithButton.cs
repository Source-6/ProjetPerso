using UnityEngine;
using UnityEngine.UI;

public class InteractWithButton : MonoBehaviour
{
    [SerializeField] PlayerBehavior player;
    [SerializeField] Button craftButton;


    public void Initialize()
    {
        craftButton = craftButton.GetComponent<Button>();
        craftButton.interactable = false;

        
    }

    public void Process()
    {
        
    }
}
