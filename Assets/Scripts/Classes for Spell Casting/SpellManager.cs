using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellManager : MonoBehaviour
{
    public Dictionary<int, Spell> availableSpells = new Dictionary<int, Spell>();
    public Spell[] skillSlots = new Spell[5]; // Changed to public for access in SpellSlotManager

    public SpellManager()
    {
        // Optionally add a basic spell as default
    }

    void FixedUpdate()
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
            Debug.Log("Invalid slot index");
            return;
        }

        Spell spell = skillSlots[slotIndex];
        if (spell != null)
        {
            spell.Cast();
        }
        else
        {
            Debug.Log("No spell assigned to this slot");
        }
    }

    public void AssignSpellToSlot(int slotIndex, int spellID)
    {
        if (slotIndex < 0 || slotIndex >= skillSlots.Length)
        {
            Debug.Log("Invalid slot index");
            return;
        }

        if (availableSpells.TryGetValue(spellID, out Spell spell))
        {
            skillSlots[slotIndex] = spell;
        }
        else
        {
            Debug.Log("Spell not found");
        }
    }
}
