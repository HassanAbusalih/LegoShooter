using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerHP : MonoBehaviour
{
    public float health;
    public GameObject wintext;


    void Update()
    {
        if(health >= 0)
        {
            FindObjectOfType<SpawnerScore>().score++;
            wintext.SetActive(true);
        }
    }
}
