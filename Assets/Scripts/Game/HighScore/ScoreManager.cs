using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currentScoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;

    [SerializeField] private int currentScore;
    [SerializeField] private int highScore;

    void Start()
    {
        GetHighScore();
    }

    void Update()
    {
        // Put an example for the mouse to add score every right click
        if (Input.GetMouseButtonDown(1))
        {
            AddScore(1);
        }

        CurrentScoreUI();
        HighScoreUI();
    }

    // Add score for a minigame
    public void AddScore(int score)
    {
        currentScore += score;

        // If current score is greater than the high score, it will update the high score to the new score.
        if (currentScore > highScore)
        {
            highScore = currentScore;
            SetHighScore();
            highScoreText.text = "High Score: " + highScore;
        }
    }

    // Setting the high score
    public void SetHighScore()
    {
        PlayerPrefs.SetInt("score", highScore);
    }

    // Getting the high score
    public void GetHighScore()
    {
        highScore = PlayerPrefs.GetInt("score");
    }

    // Reset the current score
    public void ResetScore()
    {
        currentScore = 0;
    }

    // Reset the high score
    public void ResetHighScore()
    {
        highScore = 0;
        PlayerPrefs.SetInt("score", 0);
    }

    // HighScore UI
    public void HighScoreUI()
    {
		//A: Nullcheck
        highScoreText.text = "High Score: " + highScore;
    }
    
    // Current Score UI
    public void CurrentScoreUI()
    {
		//A: Nullcheck
        currentScoreText.text = "Score: " + currentScore;
    }
}
