using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform playerTransform;
    private float spawnRange;
    public int numEnemies;
    public float spawnDelay;

    public bool canSpawn = false;

    private IEnumerator Spawn(float delay)
    {
        while (canSpawn)
        {
            yield return new WaitForSeconds(delay);
            SpawnEnemies();
        }
    }

    private void Update()
    {
        if (canSpawn && !IsInvoking("SpawnEnemies"))
        {
            InvokeRepeating("SpawnEnemies", 0, spawnDelay);
        }
        else if (!canSpawn && IsInvoking("SpawnEnemies"))
        {
            CancelInvoke("SpawnEnemies");
        }

    }
    public void SpawnEnemies()
    {
        for (int i = 0; i < numEnemies; i++)
        {
            //Spawn range
            spawnRange = UnityEngine.Random.Range(20, 35);

            // Generate a random angle between 0 and 360 degrees
            float angle = UnityEngine.Random.Range(0f, 360f);
            
            // Convert the angle to radians
            float angleRad = angle * Mathf.Deg2Rad;
            
            // Calculate the enemy position using trigonometry
            float enemyX = playerTransform.position.x + spawnRange * Mathf.Cos(angleRad);
            

            float enemyY = playerTransform.position.y + spawnRange * Mathf.Sin(angleRad);

            // Spawn the enemy at the calculated position
            Instantiate(enemyPrefab, new Vector3(enemyX, enemyY, 0f), Quaternion.identity);
        }
    }
}
