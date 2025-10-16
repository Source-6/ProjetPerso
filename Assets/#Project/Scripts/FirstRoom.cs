using UnityEngine;

public class FirstRoom : MonoBehaviour
{
    private int left, right, top, bottom;
    public void Initialise(int left, int right, int top, int bottom)
    {
        this.left = left;
        this.right = right;
        this.top = top;
        this.bottom = bottom;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
