using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 15f;       // Bullet speed
    public float lifetime = 3f;

    private Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get Rigidbody

        rb.linearVelocity = -transform.right * speed;   // Set forward motion

        Destroy(gameObject, lifetime);  // Auto-destroy after lifetime
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);    // Destroy on collision
    }
}
