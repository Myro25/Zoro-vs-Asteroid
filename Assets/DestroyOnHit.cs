using UnityEngine;

public class DestroyOnHit : MonoBehaviour
{
    public GameObject smallAsteroidPrefab;
    public float splitForce = 5f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Missile"))
        {
            Vector3 position = transform.position;

            if (CompareTag("BigAsteroid"))
            {
                // Crée 2 petits
                for (int i = 0; i < 2; i++)
                {
                    GameObject small = Instantiate(smallAsteroidPrefab, position, Quaternion.identity);
                    Rigidbody rb = small.GetComponent<Rigidbody>();

                    Vector3 randomDir = (Random.onUnitSphere + Vector3.up * 0.3f).normalized;
                    rb.AddForce(randomDir * splitForce, ForceMode.Impulse);
                }

                FindFirstObjectByType<LevelProgressManager>().AddScore(20);
            }
            else if (CompareTag("SmallAsteroid"))
            {
                FindFirstObjectByType<LevelProgressManager>().AddScore(10);
            }

            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindFirstObjectByType<GameOverManager>().TriggerGameOver();
        }
    }
}