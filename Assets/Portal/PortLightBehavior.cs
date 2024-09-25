using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortLightBehavior : MonoBehaviour
{
    public Transform[] lights; // Array to hold the lights
    public float radius = 5f; // Radius of the circle
    public float speed = 5f; // Speed of the rotation
    public float centerHeight = 0f; // Height of the center point

    private float angle = 0f;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the positions of the lights
        UpdateLightPositions();
    }

    // Update is called once per frame
    void Update()
    {
        // Update the angle based on the speed
        angle += speed * Time.deltaTime;
        UpdateLightPositions();
    }

    void UpdateLightPositions()
    {
        float angleStep = 360f / lights.Length;
        for (int i = 0; i < lights.Length; i++)
        {
            float currentAngle = angle + i * angleStep;
            float radian = currentAngle * Mathf.Deg2Rad;
            Vector3 localPosition = new Vector3(centerHeight, Mathf.Cos(radian) * radius, Mathf.Sin(radian) * radius + 0);
            lights[i].localPosition = localPosition;
        }
    }
}
