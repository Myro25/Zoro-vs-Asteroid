using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void StartGame()
    {
        Debug.Log("Bouton Start cliqué !");
        SceneManager.LoadScene("GameScene");
    }
}