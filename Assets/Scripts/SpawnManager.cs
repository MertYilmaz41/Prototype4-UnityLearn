using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    //private Enemy enemyScript;
    private float spawnRange = 9.0f;
    public int enemyCount;
    public int waveNumber = 1;
    void Start()
    {
        //enemyScript = GetComponent<Enemy>();
        SpawnEnemyWave(waveNumber);
        
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            
        }

      
    }

    void SpawnEnemyWave(int enemiesToSpawn) 
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
        
    }

    private Vector3 GenerateSpawnPosition() 
    {
        float spawnPositionX = Random.Range(-spawnRange, spawnRange);
        float spawnPositionZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPosition = new Vector3(spawnPositionX, 0, spawnPositionZ);

        return randomPosition;
       
    }

}
