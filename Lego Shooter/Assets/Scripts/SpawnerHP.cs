using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerHP : MonoBehaviour
{
    public float health;

    void Update()
    {
        if (health <= 0)
        {
            FindObjectOfType<SpawnerScore>().score++;
            Destroy(gameObject);
        }
    }
}
