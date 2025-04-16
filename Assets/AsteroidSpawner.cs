using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public float spawnInterval = 2f;
    public float spawnDistance = 10f;
    public float asteroidSpeed = 2f;
    public Transform player; // L'objet qui vise (caméra gyroscope)

    void Start()
    {
        InvokeRepeating("SpawnAsteroid", 2f, spawnInterval);
    }

    void SpawnAsteroid()
    {
        Vector3 spawnDirection = Random.onUnitSphere;
        spawnDirection.y = Mathf.Clamp(spawnDirection.y, -0.5f, 0.5f);

        Vector3 spawnPosition = player.position + spawnDirection * spawnDistance;

        spawnPosition = new Vector3(spawnPosition.x,Mathf.Abs(spawnPosition.y),spawnPosition.z);

        GameObject asteroid = Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);

        Rigidbody rb = asteroid.GetComponent<Rigidbody>();
        rb.linearVelocity = (player.position - spawnPosition).normalized * asteroidSpeed;
    }
}