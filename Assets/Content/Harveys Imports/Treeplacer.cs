using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Treeplacer : MonoBehaviour
{
    public GameObject treePrefab;

    public TerrainData terrainData;
    [SerializeField] private bool update = false;
    public float treeamount = 50;

    private void Update()
    {
        if (update != false)
        {
            for (int m = 0; m <= treeamount; m++)
            {
                PlaceTree();
            }
            update = false;
        }
    }

    public void Start()
    {
        for(int m = 0;m <= treeamount; m++)
        {
            PlaceTree();
        }
    }

    public void PlaceTree()
    {

        float x = Random.Range(0f, terrainData.size.x);
        float y = Random.Range(0f, terrainData.size.z);
        float rotation = Random.Range(0f, 360);


        float height = terrainData.GetHeight(Mathf.RoundToInt(x), Mathf.RoundToInt(y));


        Vector3 treePosition = new Vector3(x, (height), y);
        Instantiate(treePrefab, treePosition, Quaternion.Euler(0, rotation, 0));
    }
}

