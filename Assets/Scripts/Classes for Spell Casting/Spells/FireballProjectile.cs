using UnityEngine;

public class FireballProjectile : MonoBehaviour
{
    public float travelSpeed = 6f; // Set this value based on the spell's travel speed
    public float damage = 10f; // Set this value based on the spell's damage
    private Vector3 direction;
    private float timeToLive = 9f; // Set this value based on the spell's time to live
    private GameObject owner; // Reference to the owner of the fireball

    private void Update()
    {
        timeToLive -= Time.deltaTime;
        if (timeToLive <= 0)
        {
            Destroy(gameObject);
        }

        // Move in the set direction
        transform.position += direction * travelSpeed * Time.deltaTime;

        // Ensure that the y position of the projectile is always at 1.5
        Vector3 newPosition = new Vector3(transform.position.x, 1.5f, transform.position.z);
        transform.position = newPosition;
    }

    public void SetTarget(Vector3 targetPosition)
    {
        direction = (targetPosition - transform.position).normalized;
    }

    public void SetOwner(GameObject owner)
    {
        this.owner = owner;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Ignore collisions with the owner
        if (collision.gameObject == owner)
        {
            return;
        }

        Debug.Log("Hit " + collision.gameObject.name + " for " + damage + " damage");

        // Check if the collided object has the "Enemy" tag
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Get the EnemyBehavior component and apply damage
            EnemyBehavior enemy = collision.gameObject.GetComponent<EnemyBehavior>();
            if (enemy != null)
            {
                // Start the TakeDamage coroutine
                StartCoroutine(enemy.TakeDamage(damage));
                // Destroy the fireball projectile after collision
                Destroy(gameObject);
            }
        }

        // Destroy the fireball projectile after collision
        Destroy(gameObject);
    }
}
