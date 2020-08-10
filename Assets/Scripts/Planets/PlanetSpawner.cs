using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlanetSpawner : MonoBehaviour
{
    public GameObject[] planetPrefabs;

    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;
 
    private Transform playerTransform;
  
    private float spawnZ = -2.0f;
    private float planetLength = 600.0f;

    private float safeZone = 630.0f;
    private int amtOfTileOnScreen = 5;

    private int lastPrefabIndex = 0;
    
  


    private List<GameObject> activePlanets;
 
    // Start is called before the first frame update
    void Start()
    {
   
        activePlanets = new List<GameObject>();

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        for (int i = 0; i< amtOfTileOnScreen; i++)
        {
           
            if (i < 1)
            {
                SpawnPlanet(0);
             
            }     
            else
            {
               
                SpawnPlanet();
                
            }      
        }
       
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if(playerTransform.position.z - safeZone  > (spawnZ - amtOfTileOnScreen * planetLength))
        {
            SpawnPlanet();
            
            DeletePlanets();
          
        }
       
        
    }

  


    private void SpawnPlanet(int prefabindex = -1)
    {
        GameObject go;
        if(prefabindex == -1)
        {
            go = Instantiate(planetPrefabs[RandomPrefabIndex()]) as GameObject;
        }
        else
        {
            go = Instantiate(planetPrefabs[prefabindex]) as GameObject;
        }
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += planetLength;
        activePlanets.Add(go);
    }

    private void DeletePlanets()
    {
        Destroy(activePlanets[0]);
        activePlanets.RemoveAt(0);
    }

    private int RandomPrefabIndex()
    {
        if (planetPrefabs.Length <= 1)
        {
            return 0;
        }
        int randomIndex = lastPrefabIndex;
        while(randomIndex == lastPrefabIndex)
        {
            
            randomIndex = UnityEngine.Random.Range(0, planetPrefabs.Length);
        }

        lastPrefabIndex = randomIndex;
        return randomIndex;
    }
  

}
