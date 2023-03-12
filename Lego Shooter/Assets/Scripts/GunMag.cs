using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMag : GunPart, IGunPart
{
    public int totalBullets;
    public int pellets;
    public int bullets;
    public float damage;
    public float reloadTime;

    public GunPart GetGunPart()
    {
        return this;
    }

    private void Awake()
    {
        partType = PartType.Mag;
    }
}
