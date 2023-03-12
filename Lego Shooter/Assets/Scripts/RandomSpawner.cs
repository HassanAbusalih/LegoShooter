using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject target;
    float Timer = 0;
    public float SpawnTime;
    GameObject gb;
    [SerializeField] float X;
    [SerializeField] float YDown;
    [SerializeField] float YUp;
    [SerializeField] float Z;
    [SerializeField] Vector3 test;


    void Update()
    {
        Timer +=  Time.deltaTime;
        if(Timer >= SpawnTime)
        {
            Spawntarget();
            Timer = 0;
        }
        Destroy(gb, SpawnTime);

    }
    void Spawntarget()
    {
        Vector3 randomSpawnPosition = new Vector3(Random.Range(X, -X), Random.Range(YDown, YUp), Random.Range(Z, -Z));
        randomSpawnPosition += test;
        GameObject GB = Instantiate(target, randomSpawnPosition, Quaternion.identity);

        gb = GB;
    }
   
}
