using UnityEngine;

public class WinManager : MonoBehaviour
{
    public GameObject winPanel;
    public int scoreToWin = 100; // Điểm để thắng

    public bool hasWon = false;


    void Update()
    {
        if (!hasWon && ScoreManager.score >= scoreToWin)
        {
            ShowWinScreen();
        }
    }

    void ShowWinScreen()
    {
        hasWon = true;

        if (winPanel != null)
        {
            winPanel.SetActive(true);
        }
        this.enabled = false;
    }
}