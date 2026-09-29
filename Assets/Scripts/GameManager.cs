using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public int hits = 0;
    //public TextMeshProUGUI scoreText;
    //public TextMeshProUGUI hitsText;
    public static GameManager gm;
    public GameObject pauseMenu;
    public GameObject gameOverMenu;
    public CloudBattleMovement battle;
    public bool cloud = true;
    public bool sephi = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        gm = this;
    }
    void Start()
    {
        battle = FindAnyObjectByType<CloudBattleMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused();
        }
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

    public void CloudAttack()
    {
        battle.CloudAttack();
    }
}
