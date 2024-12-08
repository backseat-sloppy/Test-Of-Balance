using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats instance { get; private set; }

    // Player stats
    // Health Related
    public float maxHealth = 100;
    public float currentHealth = 100;
    public float healthRegen = 1;
    public float armour = 0;

    // Mana Related
    public float maxMana = 100;
    public float currentMana;
    public float manaRegen = 1;

    // Attack Related
    public float attackDamage = 10;
    public float attackSpeed = 1;
    public float spellPower = 10;

    // Summon Related
    public float summonPower = 10;
    public float summonHP = 50;

    // Movement Related
    public float speed = 10;


    private void Update()
    {
        // Health Regen
        if (currentHealth < maxHealth)
        {
            currentHealth += healthRegen * Time.deltaTime;
        }
        else
        {
            currentHealth = maxHealth;
        }


        // Death
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            // Game Over logik ind
            //
            //
        }

        // Mana Regen
        if (currentMana < maxMana)
        {
            currentMana += manaRegen * Time.deltaTime;
        }
        else
        {
            currentMana = maxMana;
        }
    }
}
