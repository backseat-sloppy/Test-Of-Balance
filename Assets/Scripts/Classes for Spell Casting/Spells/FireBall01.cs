using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall01 : Spell
{
    public GameObject Fireball;

    public FireBall01()
    {
        Name = "Fire Ball";
        ID = 1;
        Cooldown = 5f;
        ManaCost = 10f;
        CastTime = 0.5f;
        Damage = 10f; // Set the damage value
    }

    public override void Cast()
    {
        if (Fireball == null)
        {
            Debug.Log("Fireball prefab is not assigned");
            return;
        }

        // Calculate the target position based on the cursor's location
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Vector3 targetPosition;
       
        if (Physics.Raycast(ray, out hit))
        {
            targetPosition = hit.point;
            Debug.Log("Target position: " + targetPosition);
        }
        else
        {
            // If no hit, set a default target position
            targetPosition = ray.GetPoint(100); // 100 units away from the camera
        }

        GameObject fireBall = Instantiate(Fireball, CastPoint.position, CastPoint.rotation) as GameObject;
        FireballProjectile fireballProjectile = fireBall.GetComponent<FireballProjectile>();
        if (fireballProjectile != null)
        {
            fireballProjectile.damage = Damage; // Set the damage value on the projectile
            fireballProjectile.SetTarget(targetPosition); // Set the target position
        }

        Debug.Log("Casting " + Name);
    }
}
