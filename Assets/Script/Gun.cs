using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    // Initialize variables
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    // Set bullet speed
    public float bulletSpeed = 50;

    // Update is called once per frame
    void Update()
    {
        // Check if user pressed left click
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            // Create a bullet to fire at the spawnpoint
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            // Give bullet velocity to move
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
        }
    }
}
