using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    public int CurretnLives = 5; 
    //public int MaxLives = 5;
    public Text LivesDisplay;

    public void TakeDamage(int num = 1) {
        CurretnLives -= num;
        LivesDisplay.text = CurretnLives.ToString();
    }
}
