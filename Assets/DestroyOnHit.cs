using UnityEngine;

public class DestroyOnHit : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            Destroy(collision.gameObject); // détruit l'astéroïde
            Destroy(gameObject); // détruit le missile
        }
    }
}