using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spell : MonoBehaviour
{
    public string Name { get; protected set; }
    public int ID { get; protected set; }
    public float Cooldown { get; protected set; }
    public float ManaCost { get; protected set; }
    public float CastTime { get; protected set; }

    public abstract void Cast();
}
