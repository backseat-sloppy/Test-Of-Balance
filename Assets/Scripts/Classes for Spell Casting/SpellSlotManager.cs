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
}
