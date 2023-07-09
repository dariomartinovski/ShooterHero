using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarController : MonoBehaviour
{
    public GameObject Heart;
    private int CurrentLives;
    private int MaxLives = 5;
    private List<GameObject> Hearts = new List<GameObject>();
    public LogicScript Logic;

    void Start() {
        MaxHealth();
        Logic = GameObject.FindGameObjectWithTag("LogicManager").GetComponent<LogicScript>();
    }

    public void MaxHealth() {
        for(int i = 0; i < MaxLives; i++)
        {
            AddHeart();
        }
    }

    public void AddHeart() {
        if (CurrentLives + 1 <= MaxLives)
        {
            CurrentLives++;
            GameObject newHeart = Instantiate(Heart);
            newHeart.transform.SetParent(transform);
            newHeart.transform.localScale = Vector3.one;
            Hearts.Add(newHeart);
        }
    }

    public void RemoveHeart()
    {
        if(Hearts.Count > 0)
        {
            GameObject lastHeart = Hearts[Hearts.Count - 1];
            Hearts.RemoveAt(Hearts.Count - 1);
            Destroy(lastHeart);
        }
        if (Hearts.Count == 0)
        {
            Logic.GameOver();
        }
    }
}
