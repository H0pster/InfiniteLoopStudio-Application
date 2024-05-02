using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        // check if collision is with "Player"
        if (collision.gameObject.tag == "Player")
        {
            // change scene to loss screen
            SceneManager.LoadScene(1);
        }
    }

    // Function for button on loss screen
    public void RestartGame()
    {
        // Change the scene to game scene
        SceneManager.LoadScene(0);
    }
}
