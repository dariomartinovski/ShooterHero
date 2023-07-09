using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int CurretnLives = 5;
    public int Score = 0;

    public Text ScoreDisplay;
    public Text TotalScore;
    public Text EnemiesKilled;

    public GameObject GameFinishedScreen;
    public GameObject gameWonScreen;
    public GameObject gameLostScreen;
    public bool SomethingDispalyed = false;

    public void Start() {
        SetKillsCounter();
    }

    public void TakeDamage(int num = 1) {
        CurretnLives -= num;
        ScoreDisplay.text = CurretnLives.ToString();
    }

    public void Hit() {
        Score++;
        SetKillsCounter();
    }

    public void SetKillsCounter() {
        ScoreDisplay.text = "Score: " + Score.ToString();
    }

    public void GameOver()
    {
        if (!SomethingDispalyed)
        {
            gameLostScreen.SetActive(true);
            DisplayInfo();
            SomethingDispalyed = true;
        }
    }

    public void GameWon()
    {
        if (!SomethingDispalyed)
        {
            gameWonScreen.SetActive(true);
            DisplayInfo();
            SomethingDispalyed = true;
        }
    }

    public void GamePaused() { 
        //make game paused screen
    }

    public void DisplayInfo()
    {
        GameFinishedScreen.SetActive(true);
        TotalScore.text = "Score: " + (Score * 10).ToString();
        EnemiesKilled.text = "Total enemies killed: " + Score.ToString();

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

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
