using UnityEngine;


//---------THIS SCRIPT IS UNUSED FOR NOW

[RequireComponent(typeof(SpriteRenderer))]
public class Rooms : MonoBehaviour
{
    private int left, right, top, bottom;
    private SpriteRenderer spriteRenderer;

    public void Initialise(int left, int right, int top, int bottom)
    {
        this.left = left;
        this.right = right;
        this.top = top;
        this.bottom = bottom;
    }

    public int GetLeft() { return left; }
    public int GetRight() { return right; }
    public int GetTop() { return top; }
    public int GetBottom() { return bottom; }

    protected int GetWidth()
    {
        return right - left + 1;
    }

    protected int GetHeight()
    {
        return top - bottom + 1;
    }

    public virtual GameObject Draw()
    {
        GameObject roomContainer = new GameObject("Rooms");
        Color debugColor = Color.blueViolet;

        for (int x = left; x <= right; x++)
        {
            for (int y = bottom; y <= top; y++)
            {
                GameObject tile = new GameObject("Tile");
                tile.transform.position = new Vector3(x, y, 0);
                tile.transform.localScale = Vector3.one * 6.25f;
                tile.transform.SetParent(roomContainer.transform, true);

                spriteRenderer = GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = Resources.Load<Sprite>("square");
                spriteRenderer.color = debugColor;

            }
        }
        return roomContainer;
    }

}
