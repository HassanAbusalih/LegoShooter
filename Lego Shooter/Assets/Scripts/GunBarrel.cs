using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBarrel : GunPart, IGunPart
{
    public float minRange;
    public float maxRange;
    public float bulletSpeed;

    public GunPart GetGunPart()
    {
        return this;
    }

    private void Awake()
    {
        partType = PartType.Barrel;
    }
}
