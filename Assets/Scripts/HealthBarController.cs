using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarController : MonoBehaviour
{
    public GameObject Heart;
    private int CurrentLives;
    private int MaxLives = 5;
    List<GameObject> Hearts = new List<GameObject>();

    void Start() {
        MaxHealth();
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
    }
}
