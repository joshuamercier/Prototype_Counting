using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Class variables
    public int score = 0;
    public int drops;
    public bool canDrop = true; // Flag whether player can interact with ball
    public bool hasGameStarted; // Flag whether game has started
    public bool gamePaused;

    public Vector3 spawnPos = new Vector3(-1.5f, 5.35f, 0f); // Spawn pos for player ball
    public int pointPenalty; // Penelty points for trying to cheat
    public float boundary = 5.3f;

    [SerializeField] private GameObject mainScreen;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] Text CounterText;
    [SerializeField] Text DropsText;
    [SerializeField] Text FinalScoreText;

    private void Start()
    {
        // Initialize the game UI
        CounterText.text = "Score : " + score;
        DropsText.text = "Drops : " + drops;
    }
    public void IncrementScore(int scoreToAdd)
    {
        // Increment score by value
        score += scoreToAdd;
        // Update UI
        CounterText.text = "Score : " + score;
    }

    public void DecrementDrops()
    {
        // Decrement drops by one
        drops--;
        // Update UI
        DropsText.text = "Drops : " + drops;
    }

    void SetFinalScoreText()
    {
        FinalScoreText.text = "You achieved a Score of " + score;
    }

    public void StartGame()
    {
        // Disable title screen
        mainScreen.SetActive(false);
        // Set flag
        hasGameStarted = true;
    }

    public void GameOver()
    {
        // Enable the Game Over screen
        gameOverScreen.SetActive(true);
        // Set score text
        SetFinalScoreText();
    }
    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void PauseGame()
    {
        if (gamePaused)
        {
            gamePaused = false;
            pauseScreen.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            gamePaused = true;
            pauseScreen.SetActive(true);
            Time.timeScale = 0;
        }
        

    }
}
