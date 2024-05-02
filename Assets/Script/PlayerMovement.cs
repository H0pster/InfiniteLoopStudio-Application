using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Set contants
    public float playerSpeed = 6f;
    public float jumpPower = 2f;
    public float gravity = -9.81f;

    // Initialize variables
    private Vector3 velocity;
    private CharacterController characterController;
    private bool onGround;

    // Start is called before the first frame update
    void Start()
    {
        // Get the character controller
        characterController = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // check if on the ground
        onGround = characterController.isGrounded;

        // Case one on the ground and velocty.y < 0 then set velocity to -1
        if (onGround && velocity.y < 0f)
        {
            velocity.y = -1.0f;
        }
        else // add gravity * time to simulate gravity
        {
            velocity.y += gravity * Time.deltaTime;
        }

        // Check if user pressed spacebar and on ground
        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            // add jumpPower * -3f * gravity 
            velocity.y += Mathf.Sqrt(jumpPower * -3f * gravity);
        }

        // Create the left and right movement vector
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);

        // Apply the movement and y velocity
        characterController.Move(move*Time.deltaTime*playerSpeed + velocity * Time.deltaTime);
    }
}
