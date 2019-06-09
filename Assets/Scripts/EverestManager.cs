using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class EverestManager : MonoBehaviour
{
    public GameObject[] everestPrefabs;
    private Transform playerTransform;
    private float spawnZ = -150.0f; // la nouvelle position Z du nouveau everest à ajouter
    private float everestLength = 300.0f;
    private float safeZone = 200.0f;// la zone où on peut supprimer les everest
    private int nbtilesOnScreen = 3;

    private List<GameObject> activeEverests;
 

    // Start is called before the first frame update
    void Start()
    {
        activeEverests = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        for (int i = 0; i < nbtilesOnScreen; i++)
        {
            SpawnEverest();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.z - safeZone > (spawnZ - nbtilesOnScreen * everestLength))
        {
            SpawnEverest();
            deleteEverest();
        }
    }

    //ajouter des objets everest
    private void SpawnEverest(int prefabIndex = -1)

    {
        GameObject go;
        //creer un nouveau everest
        go = Instantiate(everestPrefabs[0]) as GameObject;
        go.transform.SetParent(transform);
        //déplacer le nouveau everest
        go.transform.position = Vector3.forward * spawnZ;
        // MAJ spawnZ
        spawnZ += everestLength;
        activeEverests.Add(go);

    }
     //supprimer les premiers objets everest créés pour ne pas avoir out of memory
    private void deleteEverest()
    {
        //détruire le premier everest de la liste
        Destroy(activeEverests[0]);
        activeEverests.RemoveAt(0);
    }

}