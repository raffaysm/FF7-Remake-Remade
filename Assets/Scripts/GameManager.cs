using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scoreText;
    public static GameManager gm;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        gm = this;
    }
    void Start()
    {
        UpdateScore();
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
