using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject target;
    float Timer = 0;
    public float SpawnTime;
    GameObject gb;
    [SerializeField] int numberToSpawn;
    [SerializeField] float X;
    [SerializeField] float YDown;
    [SerializeField] float YUp;
    [SerializeField] float Z;
    [SerializeField] Vector3 test;
    public AudioSource TargetBeep;


    void Update()
    {
        Timer +=  Time.deltaTime;
        if(Timer >= SpawnTime)
        {
            TargetBeep.Play();
            for (int i = numberToSpawn; i > 0; i--)
            {
                Spawntarget();
                Destroy(gb, SpawnTime);
            }
            Timer = 0;
        }

    }
    void Spawntarget()
    {
        Vector3 randomSpawnPosition = new Vector3(Random.Range(X, -X), Random.Range(YDown, YUp), Random.Range(Z, -Z));
        randomSpawnPosition += test;
        GameObject GB = Instantiate(target, randomSpawnPosition, Quaternion.identity);

        gb = GB;
    }
   
}
