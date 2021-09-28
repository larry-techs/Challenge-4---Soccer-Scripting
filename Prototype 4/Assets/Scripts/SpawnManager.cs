using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject EnemyPRe;
    private float spawnRange = 9.0f;
    public int enemyCount;
    public int waveNumber = 1;
    public GameObject powerUpPrefab;


    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            Instantiate(powerUpPrefab, GenerateRandomPosition(), powerUpPrefab.transform.rotation);
        }
    }
    private Vector3 GenerateRandomPosition()
    {

        float spawnX = Random.Range(-spawnRange, spawnRange);
        float spawnZ = Random.Range(-spawnRange, spawnRange);
        Vector3 SpawnPos = new Vector3(spawnX, 0, spawnZ);
        return SpawnPos;
    }
    void SpawnEnemyWave( int enemiesToSpawn)
    {
        for (int i = 0; i <enemiesToSpawn; i++)
        {
            Instantiate(EnemyPRe, GenerateRandomPosition(), EnemyPRe.transform.rotation);
        }
    }
    
}
