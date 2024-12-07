using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Console : MonoBehaviour
{
    private SpellFactory spellFactory;
    private SpellSlotManager spellSlotManager;

    void Start()
    {
        spellFactory = GetComponent<SpellFactory>();
        spellSlotManager = GetComponent<SpellSlotManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            spellFactory.AddFireBallSpell();
        }
       
    }
}
