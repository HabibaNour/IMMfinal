using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    //gameobjects of prefabs
    public GameObject fencePrefab;
    public GameObject bonePrefab;
    // frequency of bone spawn and obstacle spawn
    private float boneSpawn = 1.5f;
    private float delay = 1;
    private float intervalSpawn = 3f;
    
    
    public PlayerController player;
    
    // Start is called before the first frame update
    void Start()
        // spawning depends on the level. will make higher level harder than previous
    {if (SceneManager.GetActiveScene().name == "LevelOne")
        {
            
            InvokeRepeating("SpawnFoodObjects", delay, boneSpawn);
            InvokeRepeating("SpawnObstacle", delay, intervalSpawn);
            
        }
        else if (SceneManager.GetActiveScene().name == "LevelTwo")
        {
            // change intervals to change difficulty 
            boneSpawn = 2.5f;
            intervalSpawn = 2f;
            InvokeRepeating("SpawnFoodObjects", delay, boneSpawn);
            InvokeRepeating("SpawnObstacle", delay, intervalSpawn);
        }
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        
    }
    //will spawn bones radnomly on y axis between 3 and 8
    void SpawnFoodObjects()
    {
        Vector3 spawnFoodLocation = new Vector3(10, Random.Range(3, 6), 0);
       
        
        if (!player.gameOver)
        {

            Instantiate(bonePrefab, spawnFoodLocation, bonePrefab.transform.rotation);
                
        }
    }
    //will spawn obstacles 
    void SpawnObstacle()
    {
        Vector3 spawnFenceLocation = new Vector3(10,0, 0);
        
        
        if (!player.gameOver)
        {
            Instantiate(fencePrefab, spawnFenceLocation, fencePrefab.transform.rotation);
        }
    }
  
}
