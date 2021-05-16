using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class TimerController : NetworkBehaviour
{
    [SyncVar]
    public float timeRemaining;
    [SyncVar]
    public bool timerIsRunning = false;
    public Text TimerText;
    public GameManager GameManager;
    public GameObject GameCanvas;

    int minutes;
    int seconds;

    private void Start()
    {
        timerIsRunning = true;
        GameManager = GameObject.Find("GameManager(Clone)").GetComponent<GameManager>();
        GameCanvas = GameObject.Find("GameCanvas(Clone)");
        TimerText = GameCanvas.transform.GetChild(2).GetComponent<Text>();
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                minutes = Mathf.FloorToInt(timeRemaining / 60F);
                seconds = Mathf.FloorToInt(timeRemaining - minutes * 60);
                string niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);
                TimerText.text = "TIME: " + niceTime;
            }
            else
            {
                timeRemaining = 0;
                TimerText.text = "TIME: 0:00";
                timerIsRunning = false;
                GameManager.CheckTimeWin();
            }
        }
    }
}
