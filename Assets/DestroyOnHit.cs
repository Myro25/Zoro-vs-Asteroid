using UnityEngine;

public class DestroyOnHit : MonoBehaviour
{
    private AudioClip destructionSound;
    public float volume = 1.0f;

    private void Start()
    {
        // Charge le son depuis le dossier Resources/Sound
        destructionSound = Resources.Load<AudioClip>("Sound/asteroid-explosion");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Missile"))
        {
            // Joue le son si il a été trouvé
            if (destructionSound != null)
            {
                AudioSource.PlayClipAtPoint(destructionSound, transform.position, volume);
            }
            else
            {
                Debug.LogWarning("Le son d'explosion n'a pas été trouvé !");
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
