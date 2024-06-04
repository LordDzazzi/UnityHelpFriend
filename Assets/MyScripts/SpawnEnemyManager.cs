using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] spawnEnemies;
    private float timeForWaveOnSpawn= 10f;
    public float enemyCount;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRandomEnemies());
       
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnRandomEnemies()
    {
        yield return new WaitForSeconds(timeForWaveOnSpawn);
        for (int i = 0; i < 20;i++) 
        {
        int randomPosition=Random.Range(0,spawnPoints.Length);
            int enemyRandomIndex = Random.Range(0, spawnEnemies.Length);
            Instantiate(spawnEnemies[enemyRandomIndex], spawnPoints[randomPosition].position, spawnEnemies[enemyRandomIndex].transform.rotation);
            yield return new WaitForSeconds(9);
        }
        StartCoroutine(SpawnRandomEnemies());
    }

}
