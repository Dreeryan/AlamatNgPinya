using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI currentScoreText;
    [SerializeField] TextMeshProUGUI highScoreText;

    public int currentScore;
    public int highScore;

    void Start()
    {
        CheckHighScore();
    }

    void Update()
    {
        // Put an example for the mouse to add score every right click
        if (Input.GetMouseButtonDown(1))
        {
            AddScore(1);
        }

        // If current score is greater than the high score, it will update the high score to the new score.
        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("score", highScore);
        }

        currentScoreText.text = "Score: " + currentScore;
        highScoreText.text = "High Score: " + highScore;
    }

    // Add score for a minigame
    public void AddScore(int score)
    {
        currentScore += score;
    }

    /*public void SavePlayerScore()
    {
        PlayerPrefs.SetInt("score", currentScore);
    }*/

    // Getting the high score
    public void GetHighScore()
    {
        PlayerPrefs.SetInt("score", highScore);
    }

    // Checking the high score
    public void CheckHighScore()
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
}
