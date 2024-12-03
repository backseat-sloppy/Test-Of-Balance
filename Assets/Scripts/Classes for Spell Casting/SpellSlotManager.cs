using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellSlotManager : MonoBehaviour
{
    public SpellManager spellManager;

    void Start()
    {
        if (spellManager == null)
        {
            spellManager = GetComponent<SpellManager>();
        }
    }

    public void AddSpell(int spellID, Spell spell)
    {
        spellManager.availableSpells[spellID] = spell;
    }

    public void AssignSpellToSlot(int slotIndex, int spellID)
    {
        spellManager.AssignSpellToSlot(slotIndex, spellID);
    }

    public void AssignSpellToNextAvailableSlot(int spellID)
    {
        for (int i = 0; i < spellManager.skillSlots.Length; i++)
        {
            if (spellManager.skillSlots[i] == null)
            {
                AssignSpellToSlot(i, spellID);
                Debug.Log("Spell assigned to slot " + i);
                return;
            }
        }
        Debug.Log("No available slots to assign the spell");
    }
}
