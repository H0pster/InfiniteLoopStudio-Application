using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spanwer : MonoBehaviour
{
    // Initalize variables
    public Transform obsSpawnPoint;
    // The possible projectiles to spawn
    public GameObject obsPrefab;
    public GameObject obsPrefab2;
    // Project tile speed
    public float obsSpeed;

    // Update is called once per frame
    void Update()
    { 
        // Create random chance to shoot
        if (Random.Range(0, 100) == 1)
        {
            // Set object to shoot to the "else" object
            var gameObj = obsPrefab2;

            // Randomize the speed of the projectile
            obsSpeed = Random.Range(10, 50);

            // Create 50/50 chance to shoot each projectile type
            if (Random.Range(0, 2) == 1)
            {
                gameObj = obsPrefab;
            } else
            {
                gameObj = obsPrefab2;
            }

            // Create projectile at spawnpoint and give velocity
            var bullet = Instantiate(gameObj, obsSpawnPoint.position, obsSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = obsSpawnPoint.forward * obsSpeed;
        }
    }
}
