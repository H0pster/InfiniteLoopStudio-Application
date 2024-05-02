using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform player;

    // Set contants for velocity manipulation
    public float jumpPower = 3f;
    public float gravity = -9.81f;
    private float characterVelocity = 6f;

    // Initialize variables for enemy movement
    private Vector3 movementDirection;
    private Vector3 movementPerSecond;
    private Vector3 velocity;

    // Variables for timing when to change direction
    private float latestDirectionChangeTime;

    // Variables to check if enemy can jump/onground
    private bool onGround = false;
    private int canJump = 0; // 0 false , 1 true

    // Start is called before the first frame update
    void Start()
    {
        // Get player gameobject
        player = GameObject.FindWithTag("Player").transform;

        // Randomize left and right movement
        movementDirection = new Vector3(Random.Range(-1.0f, 1.0f), 0, 0).normalized;
        movementPerSecond = movementDirection * characterVelocity;

        // Set time to 0f
        latestDirectionChangeTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        // Make enemy/mesh look at the player for shooting and aiming
        transform.LookAt(player);
        transform.rotation *= Quaternion.Euler(0, 180, 0);
        
        // Check if onground to set velocity to 0
        if (onGround && velocity.y < 0)
        {
            velocity.y = 0f;
        }

        // Check if it has been long enough
        if (Time.time - latestDirectionChangeTime > 3f)
        {
            // set last time to new time
            latestDirectionChangeTime = Time.time;

            // Randomize the left and right movement
            movementDirection = new Vector3(Random.Range(-1.0f, 1.0f), 0, 0).normalized;
            movementPerSecond = movementDirection * characterVelocity;

        } else if (Time.time - latestDirectionChangeTime > 1f) // check if long enough for jump
        {
            // set canJump to either 0 or 1 (false or true)
            canJump = Random.Range(0, 2);
        }

        // Check if on ground and can jump
        if (canJump == 1 && onGround)
        {
            // reset canJump variable and onGround
            canJump = 0;
            onGround = false;

            // Give a upwards velocity
            velocity.y += Mathf.Sqrt(jumpPower * -3f * gravity);
        }

        // Add gravity to velocity
        velocity.y += gravity * Time.deltaTime;

        // Transform the position interms of movementPerSecond and velocity.y while keeping z the same
        transform.position = new Vector3(transform.position.x + (movementPerSecond.x * Time.deltaTime),
    transform.position.y + (velocity.y * Time.deltaTime), transform.position.z);
    }

    // To make sure enemy does not go through borders
    void OnCollisionEnter(Collision collision)
    {
        // Check if collision is with floor
        if (collision.gameObject.tag == "Floor")
        {
            // set onGround to true
            onGround = true;
        } else if (collision.gameObject.tag == "Wall") // check if collision with walls
        {
            // flip the x movement
            movementPerSecond.x = -movementPerSecond.x;
        }
    }
}
