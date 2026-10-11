using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject gameOverPanel;


    void Update()
    {
        if (playerHealth != null && playerHealth.currentHealth <= 0)
        {
            ShowGameOver();
        }
    }

    void ShowGameOver()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }
        this.enabled = false;
    }
}