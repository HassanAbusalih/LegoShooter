using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject target;


    void Update()
    {
        Spawntarget();
    }
    IEnumerator Spawntarget()
    {
        Vector3 randomSpawnPosition = new Vector3(Random.Range(10, -11), Random.Range(0, 11), Random.Range(0, 10));
        Instantiate(target, randomSpawnPosition, Quaternion.identity);
        yield return new WaitForSeconds(1f);
    }
   
}
