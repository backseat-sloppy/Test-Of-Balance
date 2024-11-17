using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballProjectile : MonoBehaviour
{
    public float travelSpeed = 4f; // Set this value based on the spell's travel speed
    public float damage = 10f; // Set this value based on the spell's damage
    private Transform target;

    private void Update()
    {
        if (target != null)
        {
            // Move towards the target
            Vector3 direction = (target.position - transform.position).normalized;
            transform.position += direction * travelSpeed * Time.deltaTime;
        }
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
    }

    private void OnCollisionEnter(Collision collision)
    {
    
            Debug.Log("Hit " + collision.gameObject.name + " for " + damage + " damage");
            // Apply damage logic here if needed
            Destroy(gameObject);
    
    }
}
