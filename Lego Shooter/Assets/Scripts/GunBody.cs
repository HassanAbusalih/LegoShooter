using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBody : GunPart, IGunPart
{
    public GameObject magAttachPoint;
    public GameObject barrelAttachPoint;
    public float rateOfFire;
    public float shotInterval;
    public float accuracy;

    public GunPart GetGunPart()
    {
        return this;
    }

    private void Awake()
    {
        partType = PartType.Body;
    }
}
