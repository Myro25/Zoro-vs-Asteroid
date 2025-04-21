using UnityEngine;
using UnityEngine.UI;

public class LevelProgressManager : MonoBehaviour
{
    public Slider progressBar;
    public int currentScore = 0;
    public int scoreToNextLevel = 100;

    public void AddScore(int amount)
    {
        currentScore += amount;
        progressBar.value = Mathf.Lerp(progressBar.value, currentScore, Time.deltaTime * 10f);

        if (currentScore >= scoreToNextLevel)
        {
            // Tu peux ajouter ici le passage au niveau suivant
            Debug.Log("Niveau suivant !");
        }
    }
}