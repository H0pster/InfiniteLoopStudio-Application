using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    // Initialize variables
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    // Set bullet speed
    public float bulletSpeed = 50;

    // Update is called once per frame
    void Update()
    {
        // Create random chance to shoot from [0,50)
        if (Random.Range(0, 50) == 1)
        {
            // Create bullet at spawnpoint and give velocity
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
        }
    }
}
