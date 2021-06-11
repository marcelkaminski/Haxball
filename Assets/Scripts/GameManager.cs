using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Mirror;

public class GameManager : NetworkBehaviour
{
    [SyncVar]
    private int score_Blue = 0;
    [SyncVar]
    private int score_Red = 0;
    public Text ScoreText;
    public Text GoalText;
    public GameObject GoalTextPanel;
    public int goalsToWin = 2;  
    //private BallScript bs;
    //public GameObject Ball;

    GameObject GameCanvas;
    

    // NetworkIdentity networkIdentity = NetworkClient.connection.identity;
    // PlayerManager = networkIdentity.GetComponent<PlayerManager>();

    void Start()
    {
        GameCanvas = GameObject.Find("GameCanvas(Clone)");
        ScoreText = GameCanvas.transform.GetChild(0).GetComponent<Text>();
        GoalTextPanel = GameCanvas.transform.GetChild(1).gameObject;
        GoalText = GoalTextPanel.transform.GetChild(0).GetComponent<Text>();
    }

    [ClientRpc]
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
        Invoke("ResetPlayers", 3.0f);
    }

    private void ShowWinMessage(string team)
    {
        GoalText.text = team.ToUpper() + " TEAM WINS";
        GoalTextPanel.SetActive(true);
        
        Invoke("RestartMatch", 3.0f);
        Invoke("HideGoalMessage", 3.0f);
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

    public void CheckTimeWin()
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

        }

        GoalTextPanel.SetActive(true);
        Invoke("RestartMatch", 3.0f);
        Invoke("HideGoalMessage", 3.0f);
    }

    private void ResetBall()
    {
        GameObject ball = GameObject.Find("Ball(Clone)");
        BallScript ballScript = (BallScript) ball.GetComponent(typeof(BallScript));
        ballScript.ResetPosition();
    }
    


    private void ResetPlayers()
    {
        GameObject[] players_Blue = GameObject.FindGameObjectsWithTag("Player_Blue");
        GameObject[] players_Red = GameObject.FindGameObjectsWithTag("Player_Red");
        float x_position = 3;
        float y_position = 2.9f;
        foreach (GameObject player_Blue in players_Blue)
        {
            player_Blue.transform.position = new Vector2 (-x_position, y_position);
            y_position -= 1.0f;
        }
        y_position = 2.9f;
        foreach (GameObject player_Red in players_Red)
        {
            player_Red.transform.position = new Vector2 (x_position, y_position);
            y_position -= 1.0f;
        }
    }

        
    private void RestartMatch()
    {
        NetworkServer.Shutdown();
    }
    
}
