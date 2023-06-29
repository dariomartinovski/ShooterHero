using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy;
    private int Offset = 22;
    private float SpawnRate = 5;
    private float SpawnTime = 0;
    private bool GameActive = true;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameActive)
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
    }

    private void SpawnEnemy()
    {
        int randPos = Random.Range((Offset * -1), Offset + 1);
        // Top Spawn
        Instantiate(Enemy, new Vector3(randPos, Offset, 0), transform.rotation);
        // Right Spawn
        Instantiate(Enemy, new Vector3(Offset, randPos, 0), transform.rotation);
        // Bottom Spawn
        Instantiate(Enemy, new Vector3(randPos, (Offset * -1), 0), transform.rotation);
        // Left Spawn
        Instantiate(Enemy, new Vector3((Offset * -1), randPos, 0), transform.rotation);
    }

    public void StopSpawning()
    {
        GameActive = false;
    }
}
