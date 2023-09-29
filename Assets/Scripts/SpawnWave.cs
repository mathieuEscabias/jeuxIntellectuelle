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

    // Start is called before the first frame update
    void Start()
    {
    }

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

        if (spawnCount < enemyCount)
        {
            Transform enemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            Enemy enemyScript = enemy.GetComponent<Enemy>();
        }
    }
}
