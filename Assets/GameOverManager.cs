using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject asteroidSpawnerObject;

    public void TriggerGameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f; // Pause le jeu
    }

    public void Retry()
    {
        Debug.Log("Retry pressed — reloading scene...");
        Time.timeScale = 1f;
        if (asteroidSpawnerObject != null)
        {
            asteroidSpawnerObject.SetActive(true); // S'il avait été désactivé
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}