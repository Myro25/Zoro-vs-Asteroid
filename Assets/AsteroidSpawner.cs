using UnityEngine;
using System.Collections.Generic;

public class AsteroidSpawner : MonoBehaviour
{
    [Header("Asteroid Settings")]
    public GameObject asteroidPrefab;
    public float spawnInterval = 2f;
    public float spawnDistance = 10f;
    public float asteroidSpeed = 2f;



    [Header("Player Reference")]
    public Transform player; // Drag la caméra AR ici

    [Header("Auto-Destruction")]
    public float destroyYThreshold = -1f;

    // Liste des astéroïdes générés
    private List<GameObject> spawnedAsteroids = new List<GameObject>();

    void Start()
    {
        Debug.Log("Spawner launched!");
        // Lancer l'apparition régulière des astéroïdes
        InvokeRepeating("SpawnAsteroid", 2f, spawnInterval);
    }

    void Update()
    {
        // Vérification pour détruire les astéroïdes tombés trop bas
        for (int i = spawnedAsteroids.Count - 1; i >= 0; i--)
        {
            GameObject asteroid = spawnedAsteroids[i];

            if (asteroid == null)
            {
                spawnedAsteroids.RemoveAt(i);
                continue;
            }

            if (asteroid.transform.position.y < destroyYThreshold)
            {
                Destroy(asteroid);
                spawnedAsteroids.RemoveAt(i);
                Debug.Log("Astéroïde détruit car tombé sous le sol !");
            }
        }
    }

    void SpawnAsteroid()
    {
        // Génère une direction aléatoire autour du joueur
        Vector3 spawnDirection = Random.onUnitSphere;
        spawnDirection.y = Mathf.Clamp(spawnDirection.y, -0.5f, 0.5f);

        // Position de spawn autour du joueur
        Vector3 spawnPosition = player.position + spawnDirection * spawnDistance;

        // On évite les valeurs négatives trop profondes dès le spawn
        spawnPosition = new Vector3(spawnPosition.x, Mathf.Abs(spawnPosition.y), spawnPosition.z);

        // Instanciation
        GameObject asteroid = Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);

        // Mouvement vers le joueur
        Rigidbody rb = asteroid.GetComponent<Rigidbody>();
        rb.linearVelocity = (player.position - spawnPosition).normalized * asteroidSpeed;

        // On ajoute à la liste pour le suivi
        spawnedAsteroids.Add(asteroid);
    }
}
