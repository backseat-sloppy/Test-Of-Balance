using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spell : MonoBehaviour
{
    public int ID { get; set; }
    public string Name { get; set; }
    public float Cooldown { get; set; }
    public float ManaCost { get; set; }
    public float CastTime { get; set; }
    public float Damage { get; set; }
    public Transform CastPoint { get; set; }

    public abstract void Cast();
}
