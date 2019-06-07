using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    private Transform playerTransform;
    private float spawnZ = 0.0f;
    private float tileLength = 10.0f;
    private int nbtiles = 7;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag ("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
