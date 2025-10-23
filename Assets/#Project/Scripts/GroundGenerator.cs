using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class GroundGenerator : MonoBehaviour
{
    [SerializeField] private int rows ;
    [SerializeField] private int columns;
    [SerializeField] private Transform tile;
    private List<Transform> tiles = new();
    private const float TILE_SIZE = 4.0f;
    [SerializeField] private float gap = 0f;

    private Vector3 pos;
    private Vector3 dim;
    private float x ;
    private float z;
    // public void Initialise()
    // {
    //     pos = transform.position;
    //     dim = transform.localScale;

    //     for (int i = 0; i < rows; i++)
    //     {            
    //         for (int j = 0; j < columns; j++)
    //         {
    //             x = i*2 + (pos.x *2 + dim.x);
    //             z = j*2+pos.z*2;
    //             Transform tileClone = Instantiate(tile);
    //             tileClone.transform.position = new Vector3(x, 0, z);
                
                
    //         }
    //     }
    // }

    public void Initialise()
    {
        // Vector3 position;
        // Vector3 rotation;
        for(x = 0f; x < columns * TILE_SIZE; x += TILE_SIZE )
        {
            for(z = 0f; z < rows * TILE_SIZE; z += TILE_SIZE)
            {
                Transform tileClone = Instantiate(tile);
                tileClone.transform.position += Vector3.right*x + Vector3.forward*z;
                tiles.Add(tileClone);
                
            }
        }
    }


}
