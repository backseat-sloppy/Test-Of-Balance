using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public Vector3 offset; // Offset of the camera from the player


    void LateUpdate()
    {
        // Update the camera's position to follow the player with the specified offset
        transform.position = player.position + offset;
    }
}