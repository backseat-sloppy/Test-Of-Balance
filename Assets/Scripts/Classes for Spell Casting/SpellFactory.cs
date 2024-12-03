using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellFactory : MonoBehaviour
{
    private SpellSlotManager spellSlotManager;


    #region Spell Prefabs

    public GameObject fireballPrefab; // Reference to the Fireball prefab
    public GameObject icePrefab; // Reference to the Ice prefab
    #endregion

    void Start()
    {
        spellSlotManager = GetComponent<SpellSlotManager>();
    }

    public void AddFireBallSpell()
    {
        FireBall01 fireBallSpell = new FireBall01();
        fireBallSpell.Fireball = fireballPrefab; // Assign the Fireball prefab
        spellSlotManager.AddSpell(fireBallSpell.ID, fireBallSpell);
        spellSlotManager.AssignSpellToNextAvailableSlot(fireBallSpell.ID);
        Debug.Log("FireBall01 spell added and assigned to the next available slot");
    }


    // Add more methods for other spells as needed
}
