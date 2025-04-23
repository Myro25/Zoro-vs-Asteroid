using UnityEngine;
using System.Collections.Generic;

public class AsteroidSpawner : MonoBehaviour
{
    [Header("Asteroid Settings")]
    public GameObject asteroidPrefab;
    public float spawnInterval = 5f;
    public float spawnDistance = 25f;
    public float asteroidSpeed = 1.5f;

    [Header("Player Reference")]
    public Transform player;

    [Header("Auto-Destruction")]
    public float destroyYThreshold = -1f;

    private List<GameObject> spawnedAsteroids = new List<GameObject>();

    void Start()
    {
        Debug.Log("Spawner launched!");
        InvokeRepeating("SpawnAsteroid", 2f, spawnInterval);
    }

    void Update()
    {
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
        Vector3 spawnDirection = Random.onUnitSphere;
        spawnDirection.y = Mathf.Clamp(spawnDirection.y, -0.5f, 0.5f);
        Vector3 spawnPosition = player.position + spawnDirection * spawnDistance;
        spawnPosition = new Vector3(spawnPosition.x, Mathf.Abs(spawnPosition.y), spawnPosition.z);

        GameObject asteroid = Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);

        Rigidbody rb = asteroid.GetComponent<Rigidbody>();
        rb.linearVelocity = (player.position - spawnPosition).normalized * asteroidSpeed;

        spawnedAsteroids.Add(asteroid);
    }
}