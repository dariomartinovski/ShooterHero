using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerTop : MonoBehaviour
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

    private void SpawnEnemy() {
        int randPos = Random.Range((HeightOffset * -1), HeightOffset + 1);
        Instantiate(Enemy, new Vector3(randPos, transform.position.y, 0), transform.rotation);
    }
}
