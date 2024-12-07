using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballProjectile : MonoBehaviour
{
    public float travelSpeed = 4f; // Set this value based on the spell's travel speed
    public float damage = 10f; // Set this value based on the spell's damage
    private Vector3 targetPosition;

    private void Update()
    {
        if (targetPosition != Vector3.zero)
        {
            // Move towards the target position
            Vector3 direction = (targetPosition - transform.position).normalized;
            transform.position += direction * travelSpeed * Time.deltaTime;

            // Check if the projectile has reached the target position
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                Destroy(gameObject);
            }
        }
    }

    public void SetTarget(Vector3 targetPosition)
    {
        this.targetPosition = targetPosition;
        Debug.Log("Setting target position to " + targetPosition);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hit " + collision.gameObject.name + " for " + damage + " damage");
        // Apply damage logic here if needed
        Destroy(gameObject);
    }
}
