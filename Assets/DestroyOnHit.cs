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

            // Crée deux astéroïdes projetés dans des directions aléatoires
            for (int i = 0; i < 2; i++)
            {
                GameObject small = Instantiate(smallAsteroidPrefab, position, Quaternion.identity);
                Rigidbody rb = small.GetComponent<Rigidbody>();

                // Direction aléatoire mais pas complètement dans toutes les directions
                Vector3 randomDir = (Random.onUnitSphere + Vector3.up * 0.3f).normalized;
                rb.AddForce(randomDir * splitForce, ForceMode.Impulse);
            }

            Destroy(collision.gameObject); // Supprime le missile
            Destroy(gameObject);           // Supprime l’astéroïde parent
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