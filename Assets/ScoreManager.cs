using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public int score = 0;
    public string username = "";

    public void IncrementScore()
    {
        score++;
    }

    public void SetUsername(string newUsername)
    {
        username = newUsername;
    }

    public int GetScore()
    {
        return score;
    }

    public string GetUsername()
    {
        return username;
    }

    public void UpdateScoreText()
    {
        scoreText.text = " Score: " + score.ToString();
    }
}

