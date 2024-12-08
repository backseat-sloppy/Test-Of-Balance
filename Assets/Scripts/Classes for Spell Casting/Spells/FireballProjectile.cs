using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FireballProjectile : MonoBehaviour
{
    public float travelSpeed = 6f; // Set this value based on the spell's travel speed
    public float damage = 10f; // Set this value based on the spell's damage
    private Vector3 direction;
    private float timeToLive = 9f; // Set this value based on the spell's time to live

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
        Debug.Log("Setting target direction to " + direction);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hit " + collision.gameObject.name + " for " + damage + " damage");
        // Apply damage logic here if needed
        Destroy(gameObject);
    }
}
