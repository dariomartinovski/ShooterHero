using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerSides : MonoBehaviour
{
    public GameObject Enemy;
    private int HeightOffset = 22;
    private float SpawnRate = 5;
    private float SpawnTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        if (SpawnTime < SpawnRate)
        {
            SpawnTime += Time.deltaTime;
        }
        else
        {
            SpawnEnemy();
            SpawnTime = 0;
        }
    }

    private void SpawnEnemy()
    {
        //make random x position
        int randPos = Random.Range((HeightOffset * -1), HeightOffset + 1);
        Instantiate(Enemy, new Vector3(transform.position.x, randPos, 0), transform.rotation);
    }
}
