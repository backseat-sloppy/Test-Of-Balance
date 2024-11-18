using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Console : MonoBehaviour
{
    private SpellSlotManager spellSlotManager;

    void Start()
    {
        spellSlotManager = GetComponent<SpellSlotManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            AddFireBallSpell();
        }
    }

    private void AddFireBallSpell()
    {
        FireBall01 fireBallSpell = new FireBall01();
        spellSlotManager.AddSpell(fireBallSpell.ID, fireBallSpell);
        Debug.Log("FireBall01 spell added to the spell list");
    }
}
