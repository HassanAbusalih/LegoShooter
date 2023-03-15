using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScore : MonoBehaviour
{
    public int score;
    public GameObject wintext;
    [SerializeField] int targetScore;

    void Update()
    {
        if (score == targetScore)
        {
            wintext.SetActive(true);
        }
    }
}
