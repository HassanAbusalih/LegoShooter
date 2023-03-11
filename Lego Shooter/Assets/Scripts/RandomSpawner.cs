using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject target;
    public float Timer;
    GameObject gb;

    void Update()
    {
        Timer +=  Time.deltaTime;
        if(Timer >= 1)
        {
            Spawntarget();
            Timer = 0;
        }
        Destroy(gb, 1);

    }
    void Spawntarget()
    {
        Vector3 randomSpawnPosition = new Vector3(Random.Range(10, -11), Random.Range(0, 11), Random.Range(0, 10));
        GameObject GB = Instantiate(target, randomSpawnPosition, Quaternion.identity);
        gb = GB;
    }
   
}
