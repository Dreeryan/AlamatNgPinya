using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
	//A: Explicitly private
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

		//A: Do this check when the score is increased rather than per frame
        // If current score is greater than the high score, it will update the high score to the new score.
        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("score", highScore);
        }
		
		//A: Only update text when the score actually changed
        currentScoreText.text = "Score: " + currentScore;
        highScoreText.text = "High Score: " + highScore;
    }

    // Add score for a minigame
    public void AddScore(int score)
    {
        currentScore += score;
		//A: This is where you can trigger the text update and high score checks instead
    }

    /*public void SavePlayerScore()
    {
        PlayerPrefs.SetInt("score", currentScore);
    }*/

    // Getting the high score
    public void GetHighScore()
    {
		//A: Why is this set if its a get?
        PlayerPrefs.SetInt("score", highScore);
    }

    // Checking the high score
    public void CheckHighScore()
    {
		//A: What exactly are you checking? This only gets (Make sure method name is doing what it says)
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
