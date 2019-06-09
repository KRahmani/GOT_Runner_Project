﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    private Transform playerTransform;
    private float spawnZ = -10.0f; // la nouvelle position Z du nouveau bridge à ajouter
    private float tileLength;
    private float safeZone = 50.0f;
    private int nbtilesOnScreen = 15;
    //private int prefIndex;

    private int lastPrefabIndex = 0;
    private List<GameObject> activeTiles;

    // Start is called before the first frame update
    void Start()
    {
        activeTiles = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag ("Player").transform;
        for(int i = 0 ; i < nbtilesOnScreen; i++)
        {
            if(i < 2)
            {
                SpawnTile(0);
            }
            else
                SpawnTile();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.z - safeZone > (spawnZ - nbtilesOnScreen * tileLength))
        {
            SpawnTile();
            deleteTiles();
        }
    }

    private void SpawnTile(int prefabIndex = -1)

    {
        GameObject go;
        if (prefabIndex == -1)
        {
            //creer un bridge de l'index choisi
            int randomPrefIndex = RandomPrefabIndex();
            go = Instantiate(tilePrefabs[randomPrefIndex]) as GameObject;
            tileLength = PrefabLength(randomPrefIndex);
        }
        else
        {
            go = Instantiate(tilePrefabs[prefabIndex]) as GameObject;
            tileLength = PrefabLength(prefabIndex);
        }
        
        go.transform.SetParent(transform);
        //déplacer le nouveau bridge
        go.transform.position = Vector3.forward * spawnZ;
        // MAJ spawnZ
        spawnZ += tileLength;
        activeTiles.Add(go);

    }

    //supprimer les premiers bridges créés pour ne pas avoir out of memory
    private void deleteTiles()
    {
        //détruire le premier bridge de la liste
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

    private int RandomPrefabIndex()
    {
        if (tilePrefabs.Length <= 1)
        {
            return 0;
        }
       
        int randomIndex = lastPrefabIndex;
        while(randomIndex == lastPrefabIndex)
        {
            randomIndex = UnityEngine.Random.Range(0, tilePrefabs.Length);
        }
        lastPrefabIndex = randomIndex;
        return randomIndex;
    }

     private int PrefabLength(int prefabIndex)
     {
         int prefabLength  = 0; 
         switch(prefabIndex)
         {
             case 0:
                 prefabLength = 10;
                 break;
             case 1:
                prefabLength = 50;
                 break;
             case 2:
                 prefabLength = 60;
                 break;
             case 3:
                prefabLength = 95;
                 break;
             case 4:
                 prefabLength = 35;
                 break;
         }
         return prefabLength;
     }
}
