using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellManager : MonoBehaviour
{
    public Dictionary<int, Spell> availableSpells = new Dictionary<int, Spell>();
    public Spell[] skillSlots = new Spell[5]; // Changed to public for access in SpellSlotManager

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            CastSpell(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CastSpell(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            CastSpell(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            CastSpell(3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            CastSpell(4);
        }
    }

    public void CastSpell(int slotIndex)
    {
        if (slotIndex < 0 || slotIndex >= skillSlots.Length)
        {
            Debug.Log("Invalid slot index: " + slotIndex);
            return;
        }

        Spell spell = skillSlots[slotIndex];
        if (spell != null)
        {
            Debug.Log("Casting spell from slot " + slotIndex);
            spell.Cast();
        }
        else
        {
            Debug.Log("No spell assigned to slot " + slotIndex);
        }
    }

    public void AssignSpellToSlot(int slotIndex, int spellID)
    {
        if (slotIndex < 0 || slotIndex >= skillSlots.Length)
        {
            Debug.Log("Invalid slot index: " + slotIndex);
            return;
        }

        if (availableSpells.TryGetValue(spellID, out Spell spell))
        {
            skillSlots[slotIndex] = spell;
            Debug.Log("Spell with ID " + spellID + " assigned to slot " + slotIndex);
        }
        else
        {
            Debug.Log("Spell with ID " + spellID + " not found in availableSpells");
        }
    }
}
