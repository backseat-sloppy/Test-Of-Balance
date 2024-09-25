using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellManager : MonoBehaviour
{
    private Dictionary<int, Spell> availableSPells = new Dictionary<int, Spell>();
    public SpellManager()
    {
        
        // Eventuelt add Basic spell som default???

    }
    public void CastSpell(int spellID)
    {
        if (availableSPells.TryGetValue(spellID, out Spell spell))
        {
            spell.Cast();
        }
        else Debug.Log("Spell not found");
    }

}
