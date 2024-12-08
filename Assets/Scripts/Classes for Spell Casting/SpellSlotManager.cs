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
        if (spell == null)
        {
            Debug.LogError("Attempted to add a null spell to the dictionary");
            return;
        }

        spellManager.availableSpells[spellID] = spell;
        Debug.Log("Spell with ID " + spellID + " added to availableSpells");
    }

    public void AssignSpellToSlot(int slotIndex, int spellID)
    {
        if (slotIndex < 0 || slotIndex >= spellManager.skillSlots.Length)
        {
            Debug.Log("Invalid slot index: " + slotIndex);
            return;
        }

        if (spellManager.availableSpells.TryGetValue(spellID, out Spell spell))
        {
            spellManager.skillSlots[slotIndex] = spell;
            Debug.Log("Spell with ID " + spellID + " assigned to slot " + slotIndex);
        }
        else
        {
            Debug.Log("Spell with ID " + spellID + " not found in availableSpells");
        }
    }

    public void AssignSpellToNextAvailableSlot(int spellID)
    {
        for (int i = 0; i < spellManager.skillSlots.Length; i++)
        {
            if (spellManager.skillSlots[i] == null)
            {
                AssignSpellToSlot(i, spellID);
                Debug.Log("Spell with ID " + spellID + " assigned to slot " + i);
                return;
            }
        }
        Debug.Log("No available slots to assign the spell with ID " + spellID);
    }
}
