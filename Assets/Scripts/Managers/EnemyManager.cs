using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject enemy;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;


    void Start ()
    {
        InvokeRepeating ("Spawn", spawnTime, spawnTime);
    }


    void Spawn()
    {
        // Nếu player đã chết, không sinh quái
        if (playerHealth != null && playerHealth.currentHealth <= 0f)
        {
            return;
        }

        // Nếu đã thắng, không sinh quái
        WinManager winManager = FindObjectOfType<WinManager>();
        if (winManager != null && winManager.hasWon)
        {
            return;
        }

        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
}
