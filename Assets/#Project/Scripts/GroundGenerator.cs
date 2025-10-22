using UnityEngine;

public class GroundGenerator : MonoBehaviour
{
    [SerializeField] private int rows ;
    [SerializeField] private int columns;
    [SerializeField] private Transform tile;
    private Vector3 dimensions;
    public void Initialise()
    {
        dimensions = transform.localScale;

        for (int i = 0; i < rows; i++)
        {
            //tile = Instantiate(tile);
            
            for (int j = 0; j < columns; j++)
            {
                Transform tileClone = Instantiate(tile);
                tileClone.transform.position = new Vector3(dimensions.x*2 +i, 0, dimensions.z*2 + j);
            }
        }
    }


}
