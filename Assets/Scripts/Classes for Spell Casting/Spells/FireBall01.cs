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
        GameObject fireBall = Instantiate(Fireball, CastPoint.position, CastPoint.rotation) as GameObject;
        FireballProjectile fireballProjectile = fireBall.GetComponent<FireballProjectile>();
        if (fireballProjectile != null)
        {
            fireballProjectile.damage = Damage; // Set the damage value on the projectile
        }

        Debug.Log("Casting " + Name);
    }
}