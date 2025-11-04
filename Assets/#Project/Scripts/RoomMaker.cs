using System.Collections.Generic;
using System.Linq;
// using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;


//---------THIS SCRIPT IS UNUSED FOR NOW
public class RoomMaker : MonoBehaviour
{
    [SerializeField] Transform cubePrefab;
    private List<Transform> cubesX = new List<Transform>();
    private List<Transform> cubesZ = new List<Transform>();
    private PrimitiveType primitiveCube = PrimitiveType.Cube;
    private List<GameObject> wallsX = new List<GameObject>();
    private List<GameObject> wallsZ = new List<GameObject>();
    private Vector3 planeDimensions;
    [SerializeField] float wallWidth;
    [SerializeField] float wallHeight;
    private float wallY = 2.5f;
    private float rndX;
    private float rndZ;
    private List<float> randoms = new List<float>();

    private void CreatePrimitiveX()
    {
        //Create first wall (x)
        GameObject primitiveX = GameObject.CreatePrimitive(primitiveCube);

        rndX = Random.Range(-planeDimensions.x/2, planeDimensions.x / 2);
        randoms.Add(rndX);

        primitiveX.transform.position = new Vector3(rndX, wallY, 0);
        primitiveX.transform.localScale = new Vector3(wallWidth, wallHeight, planeDimensions.z);
        wallsX.Add(primitiveX);

        float width = planeDimensions.x/2 - rndX;
        float xpos = rndX + width / 2;

        Debug.Log($"rdn = {rndX} width = {width}, xpos = {xpos}");

        //Create second wall based on xpos of first wall
        GameObject primitiveZ = GameObject.CreatePrimitive(primitiveCube);

        rndX = Random.Range(-10, planeDimensions.z / 2);
        primitiveZ.transform.position = new Vector3(xpos, wallY, rndX);
        primitiveZ.transform.localScale = new Vector3(width, wallHeight, wallWidth);
        wallsZ.Add(primitiveZ);
        
    }

    private void CreateWall()
    {
        int num = 0;
        while(num < 3)
        {
            cubesX = new List<Transform>();
            //wall on axe x
            rndX = Random.Range(-10,10);  //planeDimensions.x/2 (should have parsed them otherwise idk)
            int rndParsedX = (int)rndX;
            randoms.Add(rndParsedX);
            float widthX = 10 - rndParsedX;

            for(int i = 0; i < widthX ; i++)
            {
                cubesX.Add(cubePrefab);
            }
            for(int i = 0 ; i < cubesX.Count; i++)
            {
                cubePrefab = Instantiate(cubePrefab);
                cubePrefab.transform.position = new Vector3(rndX+i, 0, 0);
            }
            Debug.Log($"X : rnd = {rndX}, width = {widthX }, cubes count = {cubesX.Count} ");


            cubesZ = new List<Transform>();
            //wall on axe z
            rndZ = Random.Range(-10,10);
            int rndParsedZ = (int)rndZ;
            float widthZ = 10 - rndParsedZ;
            for(int i = 0; i < widthZ; i++)
            {
                cubesZ.Add(cubePrefab);
            }
            for(int i = 0; i < cubesZ.Count; i++)
            {
                cubePrefab = Instantiate(cubePrefab);
                cubePrefab.transform.position = new Vector3(rndX,0,rndZ+i);
                cubePrefab.transform.rotation = Quaternion.Euler(0,90,0);
            }
            Debug.Log($"Z : rnd = {rndZ}, width = {widthZ}, cubes count = {cubesZ.Count} ");
            num++;

        }


        
        


    }

    public void Initialise()
    {
        planeDimensions = transform.localScale * 10;
        CreateWall();
        // CreatePrimitiveX();

    } 

}
