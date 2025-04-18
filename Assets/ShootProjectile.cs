using TMPro;
using UnityEngine;

public class ShootProjectile : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float shootingForce = 5000f;
    public TextMeshProUGUI DebugText;
    void Start()
    {
    }
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            DebugText.text = "Screen Pressed !";

            // 1. Ray depuis le centre de l'écran
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            Vector3 direction = ray.direction;

            // 2. Instancier le projectile à la position de la caméra
            GameObject projectile = Instantiate(projectilePrefab, Camera.main.transform.position, Quaternion.LookRotation(direction));
        
            // 3. Appliquer une force dans la bonne direction
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            rb.AddForce(direction * shootingForce);
        }
    }

}