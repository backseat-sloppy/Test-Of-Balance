using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    // movement
    public Rigidbody rb;
    public float speed = 10f;

    //spell casting
    public SpellManager SpellManager;
    private List<int> playerSpells = new List<int>(); // lidt weird det her

    private void Update()
    {
        // This moves the player
        Vector2 movementInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector3 movement = new Vector3(-movementInput.x, 0, -movementInput.y);
        rb.linearVelocity = movement * speed;

        // This forces the player to look in the direction of curser
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Vector3 lookAt = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            transform.LookAt(lookAt);
        }

        //this is for the spell casting
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SpellManager.CastSpell(1);
        }

    }
}
