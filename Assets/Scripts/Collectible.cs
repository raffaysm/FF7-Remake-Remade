using TMPro;
using UnityEngine;

public class Collectible : MonoBehaviour
{

    public float rotationSpeed;
    public TextMeshProUGUI scoreText;
    public GameObject onCollectEffect;
    public int scoreCount;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateScore();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotationSpeed, 0);
    } 

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            Instantiate(onCollectEffect, transform.position, transform.rotation);
            scoreCount++;
            UpdateScore();
        }
    }

    public void UpdateScore()
    {
        if(scoreText != null)
        {
            scoreText.text = "Coins: " + scoreCount;
        }
        
    }
}
