using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Console : MonoBehaviour
{
    private SpellFactory spellFactory;

    void Start()
    {
        spellFactory = GetComponent<SpellFactory>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            spellFactory.AddFireBallSpell();
        }
       
    }
}
