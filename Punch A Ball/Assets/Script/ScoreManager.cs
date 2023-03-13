using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public int Score = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshPro bigScoreText;
    public int scoreToReach = 1000;

    private void Start()
    {
        UpdateScore();
    }
    public void AddPoints(int _points)
    {
        Score = Score + _points;
        UpdateScore();
        if(Score >= scoreToReach)
            SceneManager.LoadScene("Finished");
    }
    public void RemovePoints()
    {
        Score = Score - 10;
        UpdateScore();
    }
    public void UpdateScore()
    {
        scoreText.text = "Score: " + Score;
        bigScoreText.text = Score.ToString();
    }
}
