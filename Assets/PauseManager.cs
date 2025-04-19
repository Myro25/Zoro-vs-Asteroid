using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public void PauseGame()
    {
        Time.timeScale = 0f; // stoppe le jeu
        SceneManager.LoadScene("PauseScene", LoadSceneMode.Additive); // ouvre PauseScene par-dessus
    }
}