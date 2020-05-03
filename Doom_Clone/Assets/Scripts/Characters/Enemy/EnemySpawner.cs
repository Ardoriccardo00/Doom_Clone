//using System;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] int enemiesToSpawn;
    [SerializeField] Vector3 spawnArea;

    void Start()
    {
        
    }    

    void Update()
    {
        
    }

    public void SpawnEnemies()
    {
        for(int i = 0; i < enemiesToSpawn; i++)
        {
            var newx = Random.Range(0, spawnArea.x);
            var newy = Random.Range(0, spawnArea.y);
            var newz = Random.Range(0, spawnArea.z);

            var newPos = new Vector3(newx, newy, newz);

            Instantiate(enemyPrefab, newPos, Quaternion.identity);
        }
    }
} 