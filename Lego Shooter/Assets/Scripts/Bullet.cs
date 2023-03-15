using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    public Vector3 direction;
    public float minRange;
    public float maxRange;

    // Start is called before the first frame update
    void Start()
    {
        CheckHit();
    }

    // Update is called once per frame
    void Update()
    {
        if (damage > 0)
        {
            Destroy(gameObject, 3);
        }
    }

    void CheckHit()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, direction, out hit, maxRange))
        {
            float distance = transform.position.magnitude - hit.transform.position.magnitude;
            if (distance < minRange || distance > maxRange)
            {
                damage /= 2f;
            }
            if (hit.transform.gameObject.GetComponent<SpawnerHP>() != null)
            {
                hit.transform.gameObject.GetComponent<SpawnerHP>().health -= damage;
            }
        }
    }
}
