using UnityEngine;

public class AsteroidSplit : MonoBehaviour
{
    [Header("Split Settings")]
    public GameObject smallAsteroidPrefab;
    public int asteroidSize = 2; // 2 = grand, 1 = moyen, 0 = ne se divise plus
    public int numberOfPieces = 2;
    public float splitForce = 2f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Missile"))
        {
            if (asteroidSize > 0)
            {
                Split();
            }

            Destroy(collision.gameObject); // d�truit le missile
            Destroy(gameObject); // d�truit l'ast�ro�de
        }
    }

    void Split()
    {
        for (int i = 0; i < numberOfPieces; i++)
        {
            GameObject newAsteroid = Instantiate(
                smallAsteroidPrefab,
                transform.position,
                Random.rotation
            );

            AsteroidSplit splitScript = newAsteroid.GetComponent<AsteroidSplit>();
            if (splitScript != null)
            {
                splitScript.asteroidSize = asteroidSize - 1; // r�duit la taille
            }

            Rigidbody rb = newAsteroid.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 forceDir = Random.onUnitSphere;
                rb.AddForce(forceDir * splitForce, ForceMode.Impulse);
            }
        }
    }
}
