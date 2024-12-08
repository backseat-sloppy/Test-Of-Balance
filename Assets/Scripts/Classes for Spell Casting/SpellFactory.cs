using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellFactory : MonoBehaviour
{
    private SpellSlotManager spellSlotManager;

    #region Spell Prefabs
    public GameObject fireballPrefab; // Assign Fireball prefab in the inspector
    #endregion

    private Dictionary<int, Spell> allSpells = new Dictionary<int, Spell>();

    void Start()
    {
        spellSlotManager = GetComponent<SpellSlotManager>();
        Debug.Log("SpellFactory initialized. SpellSlotManager assigned.");

        // Initialize all available spells
        InitializeSpells();
    }

    private void InitializeSpells()
    {
        // Example of adding a FireBall01 spell to the dictionary
        if (fireballPrefab != null)
        {
            GameObject spellObject = new GameObject("FireBall01");
            FireBall01 fireBallSpell = spellObject.AddComponent<FireBall01>();
            fireBallSpell.Fireball = fireballPrefab; // Assign the Fireball prefab
            fireBallSpell.CastPoint = transform; // Assign a cast point, e.g., the transform of the SpellFactory
            fireBallSpell.SetOwner(gameObject); // Set the owner to the SpellFactory or the player

            allSpells[fireBallSpell.ID] = fireBallSpell;
            Debug.Log("FireBall01 spell initialized and added to allSpells");
        }
    }

    public void AddFireBallSpell()
    {
        if (allSpells.TryGetValue(1, out Spell fireBallSpell))
        {
            spellSlotManager.AddSpell(fireBallSpell.ID, fireBallSpell);
            Debug.Log("FireBall01 spell added to SpellSlotManager");

            spellSlotManager.AssignSpellToNextAvailableSlot(fireBallSpell.ID);
            Debug.Log("FireBall01 spell assigned to the next available slot");
        }
        else
        {
            Debug.LogError("FireBall01 spell not found in allSpells");
        }
    }
}
