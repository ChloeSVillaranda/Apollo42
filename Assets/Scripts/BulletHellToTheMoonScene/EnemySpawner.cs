using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 2f;
    public float spawnRangeX = 10f;
    public float spawnHeight = 12f;

    private float timer;
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval) {
            SpawnEnemy();
            timer = 0f;
        }
    }
    void SpawnEnemy() {
        Vector2 spawnPos = new Vector2(Random.Range(-spawnRangeX, spawnRangeX), spawnHeight);
        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
}
