using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWave : MonoBehaviour
{
    public Transform enemyPrefab;
    public int enemyCount = 5;
    public float enemysDelay = 1f;
    public float clock = 1f;
    public Transform spawnPoint;
    public int spawnCount = 0;

    // Update is called once per frame
    void Update()
    {
        clock -= Time.deltaTime;
        
        if (clock < 0f)
        {
            clock = enemysDelay;
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        spawnCount++;

        if (spawnCount < enemyCount) {
            Instantiate(enemyPrefab, spawnPoint);
        }
    }
}
