using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleSpawner : MonoBehaviour
{
    public GameObject badApplePrefabs;

    public GameObject applePrefabs;

    public float spawnDelay;

    public float badAppleChance = 0.2f;

    private void Start()
    {
       StartCoroutine(SpawnApple());  
    }
    IEnumerator SpawnApple()
    {
        while (true)
        {
            GameObject appleToSpawn = GetRandomAppleToSpawn();
            float randomXPosition = Random.Range(-8f, 8f);
            Vector3 spawnPosition = new Vector3(randomXPosition,6f,0);
            Instantiate(appleToSpawn, spawnPosition, Quaternion.identity);

            yield return new WaitForSeconds(spawnDelay);
        }
    } 

    GameObject GetRandomAppleToSpawn()
    {
        float randomNumber = Random.Range(0, 1f);
        if (randomNumber < badAppleChance)
        {
            return badApplePrefabs;
        }
        else
        {
            return applePrefabs;
        }
    }
}
