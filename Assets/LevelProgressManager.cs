using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelProgressManager : MonoBehaviour
{
    public Slider progressBar;
    public AsteroidSpawner spawner;
    public Text levelText;

    public int currentScore = 0;
    public int scoreToNextLevel = 100;
    private int level = 1;

    public void AddScore(int amount)
    {
        currentScore += amount;
        StartCoroutine(SmoothFill());

        if (currentScore >= scoreToNextLevel)
        {
            level++;
            Debug.Log("🎉 Niveau " + level + " atteint !");

            // Réinitialise la progression
            currentScore = 0;
            progressBar.value = 0;

            // Augmente la vitesse des astéroïdes
            if (spawner != null)
            {
                spawner.asteroidSpeed += 0.5f;
                Debug.Log("🚀 Nouvelle vitesse : " + spawner.asteroidSpeed);
            }

            // Augmente la difficulté
            scoreToNextLevel += 50;

            // Met à jour l'affichage du niveau (si utilisé)
            if (levelText != null)
                levelText.text = "Niveau " + level;
        }
    }

    private IEnumerator SmoothFill()
    {
        float duration = 0.3f;
        float start = progressBar.value;
        float end = currentScore;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            progressBar.value = Mathf.Lerp(start, end, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        progressBar.value = end;
    }
}