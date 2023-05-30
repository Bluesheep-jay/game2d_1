using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    public float spawnTimer;
    public float spawnMax = 25; 
    public float spawnMin = 10;
    public GameObject enemyProjectile;
    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = Random.Range(spawnMin, spawnMax);
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0)
        {
            Instantiate(enemyProjectile, transform.position, Quaternion.identity); 
            spawnTimer = Random.Range(spawnMin, spawnMax);

        }
    }
}
