using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalPlayer : MonoBehaviour
{
   // this script is a basic player controller that moves the player in the x and z axis
   // it also rotates the player based on the mouse movement
   public float speed = 5f; // Speed of the player
    public float rotationSpeed = 5f; // Speed of the rotation
        public float jumpForce = 5f; // Force of the jump
    public float gravity = 9.8f; // Gravity
    public float rotationLimit = 60f; // Limit of the rotation
    public Transform cameraTransform; // Reference to the camera
    private CharacterController characterController; // Reference to the character controller
    private Vector3 moveDirection = Vector3.zero; // Movement direction
    private float rotationX = 0f; // Rotation on the x axis
    private float rotationY = 0f; // Rotation on the y axis

    private float verticalVelocity = 0f; // Vertical velocity
    private bool isGrounded = false; // Check if the player is grounded
    
    // Start is called before the first frame update
    void Start()
    {
        // Get the character controller component
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame

    void Update()
    {
        // Check if the player is grounded
        isGrounded = characterController.isGrounded;
        // Check if the player is grounded
        if (isGrounded)
        {
            // Get the input from the keyboard
            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");
            // Calculate the movement direction
            moveDirection = new Vector3(moveX, 0, moveZ);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            // Check if the player is jumping
            if (Input.GetButtonDown("Jump"))
            {
                verticalVelocity = jumpForce;
            }
        }
        // Apply gravity
        verticalVelocity -= gravity * Time.deltaTime;
        moveDirection.y = verticalVelocity;
        // Move the player
        characterController.Move(moveDirection * Time.deltaTime);
        // Get the input from the mouse
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        // Rotate the player based on the mouse input
        rotationY += mouseX * rotationSpeed;
        rotationX -= mouseY * rotationSpeed;
        rotationX = Mathf.Clamp(rotationX, -rotationLimit, rotationLimit);
        // Rotate the camera
        cameraTransform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        // Rotate the player
        transform.rotation = Quaternion.Euler(0, rotationY, 0);
    }


}
