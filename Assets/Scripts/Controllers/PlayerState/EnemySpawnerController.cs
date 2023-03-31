using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerController : MonoBehaviour
{
    public GameObject enemyPrefab; // The prefab for the enemy game object
    public float spawnRadius = 300; // The radius within which to spawn enemies
    public float spawnInterval = 5; // The interval between spawning enemies, in seconds

    void Start()
    {
        // Invoke the Spawn method repeatedly at the specified interval
        InvokeRepeating("Spawn", 0, spawnInterval);
    }

    void Spawn()
    {
        
        // Choose a random position within the spawn radius
        var viking = GameObject.Find("viking");
        Vector3 randomPos = viking.transform.position + Random.insideUnitSphere * spawnRadius;
        
        randomPos.y = viking.transform.position.y;
        Debug.Log(randomPos);
        // Choose a random rotation for the enemy
        Quaternion randomRot = Quaternion.Euler(0, Random.Range(0, 360), 0);

        // Instantiate the enemy prefab at the random position and rotation
        Instantiate(enemyPrefab, randomPos, randomRot);
    }
}
