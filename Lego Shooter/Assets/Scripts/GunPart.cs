using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPart : MonoBehaviour
{
    public PartType partType;
}

public interface IGunPart
{
    GunPart GetGunPart();
}

public enum PartType
{
    Body = 0,
    Mag = 1,
    Barrel = 2
}
