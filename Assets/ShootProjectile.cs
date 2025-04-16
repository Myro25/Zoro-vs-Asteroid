using TMPro;
using UnityEngine;

public class ShootProjectile : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float shootingForce = 500f;
    public TextMeshProUGUI DebugText;
    void Start()
    {
    }
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            DebugText.text = "Screen Pressed ! ";
            GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * shootingForce);
        }
    }
}