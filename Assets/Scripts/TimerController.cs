using System.Collections; 
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public Text Timer;
    public float CurrentTime;
    public bool CountDown;
    public float TimerLimit;
    private bool GameActive;

    // Components
    public LogicScript Logic;

    // Start is called before the first frame update
    void Start()
    {
        Logic = GameObject.FindGameObjectWithTag("LogicManager").GetComponent<LogicScript>();
        CurrentTime = 10;
        TimerLimit = 0f;
        CountDown = true;
        GameActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameActive)
        {
            CurrentTime = CountDown ? CurrentTime -= Time.deltaTime : CurrentTime += Time.deltaTime;

            if (CurrentTime <= TimerLimit)
            {
                CurrentTime = TimerLimit;
                Logic.GameOver();
                GameActive = false;
            }

            SetTimeText();
        }
    }

    private void SetTimeText() {
        float minutes = Mathf.FloorToInt(CurrentTime / 60);
        float seconds = Mathf.FloorToInt(CurrentTime % 60);

        Timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
