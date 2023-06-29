using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    public int CurretnLives = 5; 
    public Text LivesDisplay;
    public GameObject gameOverScreen;

    public void TakeDamage(int num = 1) {
        CurretnLives -= num;
        LivesDisplay.text = CurretnLives.ToString();
    }

    public void GameOver() { 
        gameOverScreen.SetActive(true);

        PlayerController player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        player.StopMovement();

        EnemySpawner enemySpawner = FindObjectsOfType<EnemySpawner>()[0];
        enemySpawner.StopSpawning();

        EnemyController[] enemies = FindObjectsOfType<EnemyController>();
        foreach (EnemyController enemy in enemies)
        {
            enemy.StopMovement();
        }

    }
}
