using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall01 : Spell
{

    public FireBall01()
    {
        Name = "Fire Ball";
        ID = 1;
        Cooldown = 5f;
        ManaCost = 10f;
        CastTime = 0.5f;
    }

    public override void Cast()
    {
       GameObject fireBall = Instantiate(fireballPrefab, castPoint.position, castPoint.rotation) as GameObject;

        Debug.Log("Castinng " + name);
    }
}