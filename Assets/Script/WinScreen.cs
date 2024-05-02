using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    // Check if collision
    void OnCollisionEnter(Collision collision)
    {
        // if collided into Enemy
        if (collision.gameObject.tag == "Enemy")
        {
            // Switch to win screen
            SceneManager.LoadScene(2);
        }
    }

    // Set function for winscreen button "Play Again"
    public void PlayAgain()
    {
        // Switch back to game scene
        SceneManager.LoadScene(0);
    }
}
