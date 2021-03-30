using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int score_Blue = 0;
    private int score_Red = 0;

    void Start()
    {
        
    }

    public void UpdateScore(string team)
    {
        if (team == "blue")
        {
            score_Blue++;
        }
        else if (team == "red")
        {
            score_Red++;
        }
        Debug.Log(score_Blue + " : " + score_Red);
        //scoreText.text = "Score: " + score.ToString();
        Debug.Log(team + " scores");
        Invoke("RestartScene", 1.0f);
        
    }

    private void RestartScene()
    {
        SceneManager.LoadScene("StartScene");
    }
}
