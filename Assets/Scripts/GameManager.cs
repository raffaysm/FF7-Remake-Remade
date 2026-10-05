using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public int hits = 0;
    //public TextMeshProUGUI scoreText;
    //public TextMeshProUGUI hitsText;
    public static GameManager gm;
    public GameObject pauseMenu;
    public GameObject gameOverMenu;
    public Button attackButton;
    public CloudBattleMovement cloudBattle;
    public SephirothBattleMovement sephiBattle;
    public bool cloud = true;
    public bool sephi = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        gm = this;
    }
    void Start()
    {
        cloudBattle = FindAnyObjectByType<CloudBattleMovement>();
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
        cloudBattle.CloudAttack();
    }

    public void Combat()
    {
        if (cloud)
        {
            attackButton.interactable = true;
        }

        if (sephi)
        {
            attackButton.interactable = false;
            sephiBattle.SephiAttack();
        }
    }
}
