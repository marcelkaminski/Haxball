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

    void Start()
    {
        
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
        ScoreText.text = score_Blue + " : " + score_Red;
        GoalText.text = team.ToUpper() + " TEAM SCORES";
        GoalTextPanel.SetActive(true);
        //Invoke("RestartScene", 1.0f);
        Invoke("Foo", 1.0f);
        
    }

    private void RestartScene()
    {
        SceneManager.LoadScene("StartScene");
    }

    private void Foo()
    {
        GoalTextPanel.SetActive(false);
    }
}
