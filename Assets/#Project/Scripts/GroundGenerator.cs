using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Collider))]
public class GroundGenerator : MonoBehaviour
{
    [SerializeField] private int rows;
    [SerializeField] private int columns;
    [SerializeField] private Transform tile;
    private List<Transform> tiles = new();
    private const float TILE_SIZE = 4.0f;
    private Vector3 pos;
    private Vector3 dim;
    private float x;
    private float z;


    public void Initialize()
    {
        // Vector3 position;
        // Vector3 rotation;
        for (x = 0f; x < columns * TILE_SIZE; x += TILE_SIZE)
        {
            for (z = 0f; z < rows * TILE_SIZE; z += TILE_SIZE)
            {
                Transform tileClone = Instantiate(tile);
                tileClone.transform.position += Vector3.right * x + Vector3.forward * z;
                tiles.Add(tileClone);

            }
        }
    }


}
