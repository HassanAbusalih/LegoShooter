using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    Vector3 initialPos;
    public float minRange;
    public float maxRange;

    // Start is called before the first frame update
    void Start()
    {
        initialPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Hit()
    {
        float distance = transform.position.magnitude - initialPos.magnitude;
        if (distance < minRange || distance > maxRange)
        {
            damage /= 2f;
        }
    }
}
