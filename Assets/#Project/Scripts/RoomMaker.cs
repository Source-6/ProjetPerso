using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoomMaker : MonoBehaviour
{

    private PrimitiveType primitiveCube = PrimitiveType.Cube;
    private List<GameObject> wallsX = new List<GameObject>();
    private List<GameObject> wallsZ = new List<GameObject>();
    private Vector3 planeDimensions;
    [SerializeField] float wallWidth;
    [SerializeField] float wallHeight;
    private float wallY = 2.5f;
    private float rnd;
    private List<float> randoms = new List<float>();
    private int lastIndex;

    private void CreatePrimitiveX()
    {
        GameObject primitiveX = GameObject.CreatePrimitive(primitiveCube);

        rnd = Random.Range(-10, planeDimensions.x / 2);
        randoms.Add(rnd);

        primitiveX.transform.position = new Vector3(rnd, wallY, 0);
        primitiveX.transform.localScale = new Vector3(wallWidth, wallHeight, planeDimensions.z);
        wallsX.Add(primitiveX);

        float width = planeDimensions.x/2 - rnd;
        float xpos = rnd + width / 2;

        Debug.Log($"rdn = {rnd} width = {width}, xpos = {xpos}");

        GameObject primitiveZ = GameObject.CreatePrimitive(primitiveCube);

        rnd = Random.Range(-10, planeDimensions.z / 2);
        primitiveZ.transform.position = new Vector3(xpos, wallY, rnd);
        primitiveZ.transform.localScale = new Vector3(width, wallHeight, wallWidth);
        
    }

    public void Initialise()
    {
        planeDimensions = transform.localScale * 10;

        CreatePrimitiveX();
        // CreatePrimitiveZ();

    } 

}
