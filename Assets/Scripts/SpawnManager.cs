using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject[] enemyPrefab;
    public GameObject powerPrefab;
    private float spawnRange = 9.0f;
    public int enemyCount;
    public int enemyHardCount;
    public int waveNumber = 1;


    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        Instantiate(powerPrefab, GenerateSpawnPosition(), powerPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        enemyHardCount = FindObjectsOfType<EnemyHard>().Length;

        if(enemyCount == 0 && enemyHardCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            Instantiate(powerPrefab, GenerateSpawnPosition(), powerPrefab.transform.rotation);
        }
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            int randomEnemy = Random.Range(0, 2);
            Instantiate(enemyPrefab[randomEnemy], GenerateSpawnPosition(), enemyPrefab[randomEnemy].transform.rotation);
        }
        
    }

    private Vector3 GenerateSpawnPosition()
    {
        float randomSpawnX = Random.Range(-spawnRange, spawnRange);
        float randomSpawnZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(randomSpawnX, 0, randomSpawnZ);

        return randomPos;
    }

}
