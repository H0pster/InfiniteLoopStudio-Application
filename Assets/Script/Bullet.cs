using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Set how long we want the projectiles to last for
    public float life = 3;

    void Awake()
    {
        // Destory the gameObject inorder to stop flooding the scene
        Destroy(gameObject, life);
    }
}
