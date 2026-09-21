using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public int hits = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI hitsText;
    public static GameManager gm;
    public GameObject pauseMenu;
    public GameObject gameOverMenu;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        gm = this;
    }
    void Start()
    {
        UpdateScore();
        UpdateHits();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void isPaused()
    {
        Time.timeScale = 0f;
        Pause();
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
    }

    public void isResumed()
    {
        Time.timeScale = 1f;
        Resume();
    }

    public void close()
    {
        Application.Quit();
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
    }

    public void AddScore()
    {
        score++;
        UpdateScore();
    }

    public void UpdateScore()
    {
        scoreText.text = "Coins: " + score;
    }
    public void AddHits()
    {
        hits++;
        UpdateHits();
    }

    public void UpdateHits()
    {
        hitsText.text = "Hits: " + hits + "/5";
        if(hits==5)
        {
            Debug.Log("GAME OVER!!!");
            Time.timeScale = 0f;
            gameOverMenu.SetActive(true);
        }
    }
}
