using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int score_Blue = 0;
    private int score_Red = 0;
    public Text ScoreText;
    public Text GoalText;
    public GameObject GoalTextPanel;
    public int goalsToWin = 2;  
    private TimerController timer;
    private BallScript bs;
    public GameObject Ball;
    
    void Start()
    {
        timer = GetComponent<TimerController>();
        bs = Ball.GetComponent<BallScript>();
    }

    void Update()
    {
        if (!timer.timerIsRunning)
        {
            CheckTimeWin();           
        }
    }

    public void UpdateScore(string team)
    {
        if (team == "blue")
        {
            score_Blue++;
            GoalText.color = Color.blue;
        }
        else if (team == "red")
        {
            score_Red++;
            GoalText.color = Color.red;
        }
        ScoreText.text = "SCORE: " + score_Blue + " : " + score_Red;
        ShowGoalMessage(team);
        CheckScoreWin(score_Blue, score_Red);

    }

    private void ShowGoalMessage(string team)
    {
        GoalText.text = team.ToUpper() + " TEAM SCORES";
        GoalTextPanel.SetActive(true);
        Invoke("HideGoalMessage", 3.0f);
        Invoke("ResetBall", 3.0f);
    }

    private void ShowWinMessage(string team)
    {
        GoalText.text = team.ToUpper() + " TEAM WIN";
        GoalTextPanel.SetActive(true);
        
        Invoke("RestartMatch", 5.0f);
        Invoke("HideGoalMessage", 5.0f);
    }
    
    private void HideGoalMessage()
    {
        GoalTextPanel.SetActive(false);
    }

    private void CheckScoreWin(int score_Blue, int score_Red)
    {
        if (score_Red >= goalsToWin)
        {
            ShowWinMessage("red");
        }
        else if (score_Blue >= goalsToWin)
        {
            ShowWinMessage("blue");
        }
    }

    private void RestartMatch()
    {
        SceneManager.LoadScene("StartScene");
    }

    private void CheckTimeWin()
    {
        if (score_Red > score_Blue)
        {
            ShowWinMessage("red");
        }
        else if (score_Red < score_Blue)
        {
            ShowWinMessage("blue");
        }
        else
        {
            GoalText.color = Color.white;
            GoalText.text = "DRAW";
            GoalTextPanel.SetActive(true);
            Invoke("RestartMatch", 5.0f);
            Invoke("HideGoalMessage", 5.0f);
        }
    }

    private void ResetBall()
    {
        bs.ResetBallPosition();
    }
}
