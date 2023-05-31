using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy5Gun : MonoBehaviour
{
    public GameObject EnemyDirPro;

    public float spawnTimer;
    public float spawnMax = 25;
    public float spawnMin = 10;
    GameController m_gc;
    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = Random.Range(spawnMin, spawnMax);
        m_gc = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_gc.GetScore() > 50)
        {
            spawnMax = 0.8f;
            spawnMin = 0.2f;
        }

        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0) 
        {
            Instantiate(EnemyDirPro, transform.position, Quaternion.identity);
            spawnTimer = Random.Range(spawnMin, spawnMax);
        }
    }
   
}
